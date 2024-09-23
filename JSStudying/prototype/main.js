'use strict';
//!exmaples use strict:
// userName = 'Ivan';
// console.log(userName);
// console.log(window);

// function f() {
//   console.log(this);
// }
// f();

//!Прототипи - механізм, за допомогою якого об'єкти
//!в JavaScript наслідують властивості один від одного
// const user = { firstName: 'Ivan' };
// console.log(user);
// console.log(user.toString());
// console.log(user.test());

// const arr = [1, 2, 5, 7];
// console.log(arr);
// Object.prototype.sayHello = () => console.log('Hello World');
// arr.sayHello();
// user.sayHello();

//!будь-який об'єкт створюється за допомогою функції конструктора або класу
// const obj1 = {};
// const obj2 = new Object();
// console.log(obj1);
// console.log(obj2);
// const a = new Number(111);
// const b = new String('Hello');
// console.log(a);
// console.log(b);
// console.log(typeof a);
// console.log(typeof b);

// const sum = new Function('a', 'b', 'return a + b');
// console.log(typeof sum);
// console.log(sum(2, 5));

//!Проблема дублювання коду
// function User(firstName, lastName) {
//   this.firstName = firstName;
//   this.lastName = lastName;
//   this.printFullName = function () {
//     console.log('Hello from ' + this.firstName);
//   }
// }
// const user1 = new User('Ivan', 'Ivanov');
// const user2 = new User('Petr', 'Petrov');
// console.log(user1);
// console.log(user2);
// user1.printFullName();
// user2.printFullName();
// console.log(user1.printFullName === user2.printFullName);

// function User(firstName, lastName) {
//   this.firstName = firstName;
//   this.lastName = lastName;
// }
// User.prototype.printFullName = function () {
//   console.log('Hello from ' + this.firstName);
// }
// const user1 = new User('Ivan', 'Ivanov');
// const user2 = new User('Petr', 'Petrov');
// console.log(user1);
// console.log(user2);
// user1.printFullName();
// user2.printFullName();
// console.log(user1.printFullName === user2.printFullName);

//!посилання
// const a = { value: 1 };
// const b = a;
// const c = { value: a, first: 'one' };
// console.log(a.value);//1
// console.log(c.value);//?
// console.log(a);
// console.log(c.value.value);//1

//!__proto__ - це посилання на prototype
// const main = { test: 666 };
// const obj1 = { v: main };
// const obj2 = { v: main };
// console.log(obj1.v === obj2.v);//true
// console.log(obj1.__proto__ === obj2.__proto__);//true
// console.log(obj1.v);
// console.log(obj1.__proto__);
// console.log(Object.prototype);


//! майже будь-який об'єкт створюється за допомогою функції конструктора
// const v1 = { firstName: 'Petr' };//new Object
// const v1_2 = { firstName: 'Ivan' };//new Object
// const v2 = [1, 2, 3];//new Array
// const v3 = function () { console.log('v3') };//new Function
// const v4 = () => { console.log('v4') };//new Function
// function v5() { console.log('v5') };//new Function
// class v6 { };//new Function
// const v7 = 1;//new Number
// const v7_2 = 2;//new Number
// const v8 = 'one';//new String
// const v9 = true;//new Boolean

//!Майже все має __proto__
// console.log(v1.__proto__);
// console.log(v1_2.__proto__);
// console.log(v2.__proto__);
// console.log(v3.__proto__);
// console.log(v4.__proto__);
// console.log(v5.__proto__);
// console.log(v6.__proto__);
// console.log(v7.__proto__);
// console.log(v7_2.__proto__);
// console.log(v8.__proto__);
// console.log(v9.__proto__);

//!prototype є тільки у функцій конструкторів та класі
// class User {
//   constructor(firstName) {
//     this.firstName = firstName;
//   }
//   print() {
//     console.log('hello');
//   }
// }
// const user1 = new User('Petr');
// const user2 = new User('Ivan');
// console.log(user1.prototype);//undefined
// console.log(user1.__proto__);
// console.log(user2.__proto__);
// console.log(User.prototype);
// console.log(user1.__proto__ === User.prototype);
// console.log(user2.__proto__ === User.prototype);
// console.log(user1.__proto__ === user2.__proto__);

//!Як зрозуміти, на що посилається __proto__?
//!А за допомогою якої функції конструктора був створений об'єкт?
// const a = 1;
// console.log(a.__proto__ === Number.prototype);

// const st = 'Hello';
// console.log(st.__proto__ === String.prototype);

// function sum(a, b) {
//   console.log(a + b);
// }
// console.log(sum.__proto__ === Function.prototype);

// const numbers = [1, 2, 3];
// console.log(numbers.__proto__ === Array.prototype);

// const user = {firstName: 'Petr'};
// console.log(user.__proto__ === Object.prototype);

// class User{
//   constructor(firstName){
//     this.firstName = firstName;
//   }
// }
// const u = new User('Ivan');
// console.log(u.__proto__ === User.prototype);

//!__proto__ vs prototype
// const shape = { background: 'white', border: 'black' };
// console.log(shape.prototype);
// console.log(shape.__proto__ === Object.prototype);
// console.log(Object.prototype.__proto__);
// console.log(shape.__proto__.__proto__);

// console.log(arr.__proto__ === Array.prototype);
// console.log(Array.prototype.__proto__ === Object.prototype);//true
// console.log(arr.__proto__.__proto__ === Object.prototype);//true
// console.log(arr.__proto__.__proto__.__proto__ === null);//true
// const arr = [];
// console.log(arr.__proto__.__proto__.__proto__.__proto__ === null);

// function Shape(backgroundColor, textColor) {
//   this.backgroundColor = backgroundColor;
//   this.textColor = textColor;
// }
// const shape = new Shape('red', 'blue');
// console.log(shape.__proto__ === Shape.prototype);
// console.log(Shape.__proto__ === Function.prototype);
// console.log(Function.prototype.__proto__ === Object.prototype);
// console.log(Shape.prototype.__proto__ === Object.prototype);
// console.log(shape.__proto__.__proto__ === Object.prototype);