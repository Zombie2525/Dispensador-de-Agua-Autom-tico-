// Configuración del sensor ultrasonico
const int trigPin = 9;
const int echoPin = 10;
long duration;
int distance;

// Configuración de la válvula de solenoide
const int solenoidPin = 2;

void setup() {
  pinMode(trigPin, OUTPUT);
  pinMode(echoPin, INPUT);
  pinMode(solenoidPin, OUTPUT);
  Serial.begin(9600);
}

void loop() {
  digitalWrite(trigPin, LOW);
  delayMicroseconds(2);
  
  digitalWrite(trigPin, HIGH);
  delayMicroseconds(10);
  digitalWrite(trigPin, LOW);
  
  duration = pulseIn(echoPin, HIGH);
  distance = duration * 0.034 / 2;
  
  if (distance < 10) { // Si el objeto está a menos de 10 cm
    digitalWrite(solenoidPin, HIGH); // Activa la válvula
  } else {
    digitalWrite(solenoidPin, LOW); // Desactiva la válvula
  }

  delay(500);
}
