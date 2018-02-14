#include<Servo.h>
#include <Adafruit_GFX.h>
#include <Adafruit_SSD1306.h>

#define OLED_Address 0x3C
Adafruit_SSD1306 oled(1);

Servo serX;
Servo serY;

String serialData;
String coordinates = "TEST";

void setup() {

  serX.attach(11);
  serY.attach(10);
  Serial.begin(9600);
  Serial.setTimeout(10);
  oled.begin(SSD1306_SWITCHCAPVCC, OLED_Address);
}

void loop() {
  oled.clearDisplay();
  oled.setTextColor(WHITE);
  oled.setCursor(0,0);
  oled.println(coordinates);
  oled.display();
}

void serialEvent() {
  serialData = Serial.readString();
  coordinates = serialData;
  serX.write(parseDataX(serialData));
  serY.write(parseDataY(serialData));
}

int parseDataX(String data){
  data.remove(data.indexOf("Y"));
  data.remove(data.indexOf("X"), 1);
  return data.toInt();
}

int parseDataY(String data){
  data.remove(0,data.indexOf("Y") + 1);
  return data.toInt();
}
