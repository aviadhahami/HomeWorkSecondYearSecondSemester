class personColor {
  int r, g, b;

  public personColor(int r, int g, int b) {
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
    return (this.r+this.b+this.g)/3;
  }
}

