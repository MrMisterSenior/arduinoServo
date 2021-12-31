#include<Servo.h>

Servo servoX, servoY;
int x, y;

void setup() {
  servoX.attach(10);
  servoY.attach(11);
  servoX.write(90);
  servoY.write(90);
  Serial.begin(9600);
  Serial.setTimeout(10);
}

void loop() {
  // put your main code here, to run repeatedly:

}

void serialEvent(){
  String serialData = Serial.readString();
  for (int i = 0; i < serialData.length(); i++)
  {
    if (serialData.substring(i, i + 1) == ",")
    {
      x = serialData.substring(0, i).toInt();
      y = serialData.substring(i + 1).toInt();
      break;
    }
  }
  servoX.write(x);
  servoY.write(y);
}
