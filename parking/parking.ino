#include <Servo.h>
#include <SPI.h>
#include <MFRC522.h>

String receivedData, CurrentMode, OpenIn, OpenOut, GateInState, GateOutState, GateInControl, GateOutControl;

//RFID
#define RST_PIN 5
#define SS_PIN 53
MFRC522 mfrc522(SS_PIN, RST_PIN);
int UID[4], i;

// servo
Servo GateIn;
Servo GateOut;
#define gatein 8
#define gateout 9

//park
#define park_one 22
#define park_two 23
#define park_three 24
#define park_four 25
#define in 26
#define out 27
int led_park[4] = {22, 23, 24, 25};
int count = 0, previousState[4];

void setup() {
  Serial.begin(9600);

  //RFID
  SPI.begin();
  mfrc522.PCD_Init();

  //servo
  GateIn.attach(gatein);
  GateOut.attach(gateout);
  GateInClose();
  GateOutClose();

  //led
  pinMode(26, INPUT);
  pinMode(27, INPUT);
  for (int j = 0; j < 4; j++){
    pinMode(led_park[j], INPUT);
    previousState[j] = digitalRead(led_park[j]);
  }
}

void loop() {

  Serial.println(GateInState);
  delay(1000);
  Serial.println(GateOutState);

  for (int j = 0; j < 4; j++){
    int currentState = digitalRead(led_park[i]);

    if (currentState == LOW && previousState[i] == HIGH){
      count++;
    }
    else if (currentState == HIGH && previousState[i] == LOW){
      count--;
    }
    if (count <= 0){
      count = 0;
    }
    previousState[i] = currentState;
  }

  Serial.print("Count:");
  Serial.println(count);
  delay(1000);

  //read serial input
  if (Serial.available() > 0) {
    receivedData = Serial.readStringUntil('\n');

    //scan rfid
    if (receivedData == "scan") {
      CurrentMode = "scan";
    }
    else if (receivedData == "manual") {
      CurrentMode = "manual";
    } 
    else if (receivedData == "auto") {
      CurrentMode = "auto";
    }
    else if (receivedData == "in") {
      OpenIn = "in";
    } 
    else if (receivedData == "out") {
      OpenOut = "out";
    }
    else if (receivedData == "OpenGateIn"){
      GateInControl = "opengatein";
    }
    else if (receivedData == "CloseGateIn"){
      GateInControl = "closegatein";
    }
    else if (receivedData == "OpenGateOut"){
      GateOutControl = "opengateout";
    }
    else if (receivedData == "CloseGateOut"){
      GateOutControl = "closegateout";
    }
    else {
      CurrentMode = "";
      OpenOut = "";
      OpenIn = "";
    }
  }

  //mode scan
  if (CurrentMode == "scan"){
    ReadCard();
  }

  //mode auto
  if (CurrentMode == "auto") {
    AutoMode();
  }

  //mode manual
  if (CurrentMode == "manual"){
    ManualMode();
  }
}

//manual
void ManualMode(){
  ReadCard();

  if (GateInControl == "opengatein"){
    GateInOpen();
    GateInControl = "";
  }
  if (GateInControl == "closegatein"){
    GateInClose();
    GateInControl = "";
  }
  if (GateOutControl == "opengateout"){
    GateOutOpen();
    GateOutControl = "";
  }
  if (GateOutControl == "closegateout"){
    GateOutClose();
    GateOutControl = "";
  }
}


//auto
void AutoMode() {
  ReadCard();

  if (OpenIn == "in") {
    ComeIn();
    OpenIn = "";
  }

  if (OpenOut == "out") {
    ComeOut();
    OpenOut = "";
  }
}


//read rfid
void ReadCard() {
  if (!mfrc522.PICC_IsNewCardPresent()) {
    return;
  }

  if (!mfrc522.PICC_ReadCardSerial()) {
    return;
  }

  Serial.print("UID:");

  for (byte i = 0; i < mfrc522.uid.size; i++) {
    Serial.print(mfrc522.uid.uidByte[i] < 0x10 ? " 0" : " ");
    UID[i] = mfrc522.uid.uidByte[i];
    Serial.print(UID[i], HEX);
  }

  Serial.println("");

  mfrc522.PICC_HaltA();
  mfrc522.PCD_StopCrypto1();
}

void GateInOpen() {
  GateIn.write(90);
  GateInState = "GateIn:open";
  Serial.println(GateInState);
}

void GateInClose() {
  GateIn.write(0);
  GateInState = "GateIn:close";
  Serial.println(GateInState);
}


void GateOutOpen() {
  GateOut.write(90);
  GateOutState = "GateOut:open";
  Serial.println(GateOutState);
}

void GateOutClose() {
  GateOut.write(0);
  GateOutState = "GateOut:close";
  Serial.println(GateOutState);
}

//open close gatein
void ComeIn() {
  GateInOpen();
  if (digitalRead(in) == HIGH)
  {
    GateInClose();
  }
}


//open close gateout
void ComeOut() {
  GateOutOpen();
  if (digitalRead(out) == HIGH)
  {
    GateOutClose();
  }
}

