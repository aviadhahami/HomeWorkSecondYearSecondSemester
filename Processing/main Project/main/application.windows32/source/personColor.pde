class PersonColor {
  int r, g, b;

  public PersonColor(int r, int g, int b) {
    this.r = r;
    this.g = g;
    this.b = b;
  }

  int getR() {
    return this.r;
  }
  int getG() {
    return this.g;
  }
  int getB() {
    return this.b;
  }
  int getGrayScale() {
    return (this.r + this.g + this.b)/3;
  }
}
