// //! eventLoop
// setTimeout(function () {
//   console.log("hihi1");
// }, 1000);

// setTimeout(function () {
//   console.log("hihi2");
// }, 1000)

// setTimeout(function () {
//   console.log("hihi3");
// }, 1000);

// setTimeout(() => console.log("hihi4"), 1000);

//!
// class Person {
//   constructor(name, age) {
//     this.name = name;
//     this.age = age;
//   }

//   greet() {
//     console.log(`Hello, my name is ${this.name} and I am ${this.age} years old.`);
//   }

//   celebrateBirthday() {
//     this.age += 1;
//     console.log(`Happy Birthday to me! Now I am ${this.age} years old.`);
//   }
// }


// function Car(make, model, year) {
//   this.make = make;
//   this.model = model;
//   this.year = year;

//   this.getDescription = function () {
//     return `${this.year} ${this.make} ${this.model}`;
//   };
// }


// Array.prototype.last = function () {
//   if (this.length === 0) {
//     return undefined;
//   }
//   return this[this.length - 1];
// };


// const person1 = new Person("Alice", 30);
// person1.greet();
// person1.celebrateBirthday();

// const car1 = new Car("Toyota", "Corolla", 2020);
// console.log(car1.getDescription());

// const numbers = [1, 2, 3, 4, 5];
// console.log(numbers.last());
