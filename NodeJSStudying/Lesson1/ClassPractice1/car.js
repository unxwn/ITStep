function Car(brand, model, year) {
  this.brand = brand;
  this.model = model;
  this.year = year;

  this.drive = function () {
    console.log(`Car ${this.brand} is driving`);
  }
  this.showInfo = function () {
    console.log(`${this.brand} ${this.model} ${this.year}`);
  }
}

module.exports = Car;