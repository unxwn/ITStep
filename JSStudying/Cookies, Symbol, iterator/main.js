// function setCookie(name, value, days) {
//   let expires = "";
//   if (days) {//7
//     const date = new Date();
//     date.setTime(date.getTime() + days * 24 * 60 * 60 * 1000);
//     expires = "; expires=" + date.toUTCString();
//     console.log(expires);

//   }
//   document.cookie = name + "=" + (value || "") + expires + "; path=/";
// }

// function getCookie(name) {
//   const nameEQ = name + "=";
//   const cookiesArray = document.cookie.split(';');  
//   for (let i = 0; i < cookiesArray.length; i++) {
//     let cookie = cookiesArray[i];
//     while (cookie.charAt(0) === ' ') cookie = cookie.substring(1);
//     if (cookie.indexOf(nameEQ) === 0) return cookie.substring(nameEQ.length);
//   }
//   return null;
// }

// function deleteCookie(name) {
//   document.cookie = name + "=; path=/; Max-Age=0;";
// }

// setCookie("username", "JohnDoe", 7);
// console.log(getCookie("username"));

// deleteCookie("username");
// console.log(getCookie("username"));


// const sym1 = Symbol('foo');
// const sym2 = Symbol('foo');
// console.log(sym1);
// console.log(sym2);
// console.log(typeof sym1);
// console.log(typeof sym2);
// console.log(sym1 === sym2);

// const mySymbol1 = Symbol('mySymbol');
// const mySymbol2 = Symbol('mySymbol');
// const obj = {
//   firstName: 'Ivan',
//   [mySymbol1]: 'value1',
//   [mySymbol2]: 'value2'
// };
// console.log(obj);
// console.log(obj[mySymbol1]);
// for(const v in obj){
//   console.log(v);
// }


// const people = ["Tom", "Bob", "Sam"];
// console.log(people);
// const iterator = people[Symbol.iterator]();
// console.log(iterator);

// for (const v of people) {
//   console.log(v);
// }

// const username = "Tom";
// for(const v of username){
//   console.log(v);
// }
// function f(...arg){
//   console.log(arg);
// }
// f(..."test");
// f(...people);

// const username = "Tom";
// const iterator = username[Symbol.iterator]();
// console.log(iterator.next());

// const username = { firstName: 'Ivan', lastName: 'Ivanov' };
// const iterator = username[Symbol.iterator]();
// console.log(iterator);

// const people = ["Tom", "Bob", "Sam"];
// const iter = people[Symbol.iterator]();
// const result = iter.next();
// console.log(result);

// console.log(document.links);
// function sum() {
//   // console.log(arguments);
//   //ex1
//   // const [first] = arguments;
//   // console.log(first);
//   //ex2
//   // for (const v of arguments) {
//   //     console.log(v);
//   // }
// }
// sum(1, 2);
// sum(3, 4, 5);


// const people = ["Tom", "Bob", "Sam"];
// const iter = people[Symbol.iterator]();
// console.log(iter.next());
// console.log(iter.next());
// console.log(iter.next());
// console.log(iter.next());

// const people = ["Tom", "Bob", "Sam"];
// const iter = people[Symbol.iterator]();
// let item = null;
// while (!(item = iter.next()).done) {
//   console.log(item.value);
// }
// for(const v of people){
//   console.log(v);
// }

// const people = ["Tom", "Bob", "Sam"];
// const copy = [...people].reverse().forEach(e => console.log(e));
// console.log(people);

const people = ["Tom", "Bob", "Sam"];
function reverseArrayIterator(array) {
  let count = array.length;
  return {
    next: function () {
      if (count > 0) {
        return {
          value: array[--count],
          done: false
        };
      }
      else {
        return {
          value: undefined,
          done: true
        };
      }
    }
  }
};
const iter = reverseArrayIterator(people);
while (!(item = iter.next()).done) {
  console.log(item.value);
}

// const people = ["Tom", "Bob", "Sam"];
// function reverseArrayIterator() {
//   const array = this;
//   let count = array.length;
//   return {
//     next: function () {
//       if (count > 0) {
//         return {
//           value: array[--count],
//           done: false
//         };
//       }
//       else {
//         return {
//           value: undefined,
//           done: true
//         };
//       }
//     }
//   }
// };
// people[Symbol.iterator] = reverseArrayIterator;
// people.iterator = true;
// console.log(people);

// for (person of people) {
//   console.log(person);
// }

// const company = {
//   iterator: true,
//   employees: [
//     { name: "Tom", age: 39, position: "Senior Developer" },
//     { name: "Bob", age: 43, position: "Middle Developer" },
//     { name: "Sam", age: 28, position: "Junior Developer" },
//   ]
// };
// company[Symbol.iterator] = function () {
//   const array = this.employees;
//   let current = 0;
//   return {
//     next() {
//       if (current < array.length) {
//         return { value: array[current++].name, done: false };
//       }
//       return { value: undefined, done: true };
//     }
//   };
// };
// console.log(company);

// const iter = company[Symbol.iterator]();
// console.log(iter.next());
// console.log(iter.next());
// console.log(iter.next());
// console.log(iter.next());


// for (const employee of company) {
//   console.log(employee);
// }


console.log(typeof Symbol.iterator);
