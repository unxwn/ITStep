//!Web Storage API
//!ex1

// console.log(sessionStorage);
// console.log(localStorage);

// sessionStorage.setItem("userName", "Ragnar");
// localStorage.setItem("userName", "Ragnar");

// title.innerText = localStorage.getItem("userName");
// btnSave.onclick = () => {
//   const inputUserName = document.getElementById("userName");
//   const userName = inputUserName.value;

//   localStorage.setItem("userName", userName);
//   // location.reload();
//   title.innerText = localStorage.getItem("userName");
// }
// btnClear.onclick = () => {
//   // localStorage.clear();
//   localStorage.removeItem("userName");
//   // location.reload();
//   title.innerText = localStorage.getItem("userName");
// }

//!ex2

// window.addEventListener('load', () => {
//   video.currentTime = localStorage.time ?? 0;
//   video.volume = 0.2;
//   video.addEventListener('timeupdate', () => {
//     // console.log(video.currentTime);
//     localStorage.time = video.currentTime;
//   })
// })


//!IndexDB API
//!create db
// const request = indexedDB.open('school');
// request.onsuccess = (event) => {
//   const db = event.target.result;
//   console.log(db.name);//school
// }
// request.onerror = (event) => {
//   const error = event.target.error;
//   console.log(error.message);
// }
// request.onupgradeneeded = (event) => {
//   console.log(event.oldVersion);
//   console.log(event.newVersion);
//   const db = event.target.result;
// }

// const promise = indexedDB.databases();
// promise.then((databases) => console.log(databases));

//!delete db
// indexedDB.deleteDatabase("school");

//! info about db
// const request = indexedDB.open('school');
// request.onsuccess = (event) => {
//   const db = event.target.result;
//   console.log(db.name);//school
//   console.log(db.version);
//   console.log(db.objectStoreNames);
// }

//!створити сховище(таблиця)(можно тільки під час ствоерння б.д., або при оновленні версії)
// const request = indexedDB.open('school');
// request.onupgradeneeded = (event) => {
//   const db = event.target.result;
//   const store1 = db.createObjectStore("students", { keyPath: "id", autoIncrement: true });
//   const store2 = db.createObjectStore("users", { keyPath: "id", autoIncrement: true })
//   // console.log(store1);
//   // console.log(store1.name);
// }

//!видалили сховище(можно тільки під час оновлення версії)
// const request = indexedDB.open('school', 2);
// request.onupgradeneeded = (event) => {
//   const db = event.target.result;
//   db.deleteObjectStore("users");
// }

//!транзакії
// const request = indexedDB.open('school');
// request.onupgradeneeded = (event) => {
//   const db = event.target.result;
//   db.createObjectStore("students", { keyPath: "id", autoIncrement: true });
// }
// request.onsuccess = (event) => {
//   const db = event.target.result;
//   console.log(db);
//   const transaction = db.transaction("students", "readwrite");
//   // console.log(transaction.db.name);
//   // console.log(transaction.mode);
//   // console.log(transaction.objectStoreNames);
//   const studentsStore = transaction.objectStore("students");
//   console.log(studentsStore);
// }

//!додавання
// const request = indexedDB.open('school');
// request.onupgradeneeded = (event) => {
//   const db = event.target.result;
//   db.createObjectStore("students", { keyPath: "id", autoIncrement: true });
// }
// request.onsuccess = (event) => {
//   const db = event.target.result;
//   const transaction = db.transaction("students", "readwrite");
//   const studentsStore = transaction.objectStore("students");
//   const student = {
//     firstName: 'Petr', age: 22
//   };
//   const req = studentsStore.add(student);
//   req.onsuccess = (event) => {
//     console.log("student saved with id " + req.result);
//   }
// }

//!read
// const request = indexedDB.open('school');
// request.onsuccess = (event) => {
//   const db = event.target.result;
//   const transaction = db.transaction("students", "readwrite");
//   const studentsStore = transaction.objectStore("students");
//   const req = studentsStore.getAll();
//   req.onsuccess = (e) => {
//     const students = req.result;
//     console.log(students);
//   }
//   req.onerror = (e) => {
//     console.log(e.event.target.error);
//   }
// }

// const request = indexedDB.open('school');
// request.onsuccess = (event) => {
//   const db = event.target.result;
//   const transaction = db.transaction("students", "readwrite");
//   const studentsStore = transaction.objectStore("students");
//   const req = studentsStore.getAll(2);
//   req.onsuccess = (e) => {
//     const students = req.result;
//     console.log(students);
//   }
//   req.onerror = (e) => {
//     console.log(e.event.target.error);
//   }
// }

// const request = indexedDB.open('school');
// request.onsuccess = (event) => {
//   const db = event.target.result;
//   const transaction = db.transaction("students", "readwrite");
//   const studentsStore = transaction.objectStore("students");
//   const req = studentsStore.get(2);
//   req.onsuccess = (e) => {
//     const students = req.result;
//     console.log(students);
//   }
//   req.onerror = (e) => {
//     console.log(e.event.target.error);
//   }
// }

//!update
// const request = indexedDB.open('school');
// request.onsuccess = (event) => {
//   const db = event.target.result;
//   const transaction = db.transaction("students", "readwrite");
//   const studentsStore = transaction.objectStore("students");
//   const req = studentsStore.get(2);
//   req.onsuccess = () => {
//     const student = req.result;
//     student.age = 23;
//     const updateReq = studentsStore.put(student);
//     updateReq.onsuccess = () => console.log('updated');
//     updateReq.onerror = () => console.log('error');
//   }
// }

//!count
// const request = indexedDB.open('school');
// request.onsuccess = (event) => {
//   const db = event.target.result;
//   const transaction = db.transaction("students", "readwrite");
//   const studentsStore = transaction.objectStore("students");
//   const reqSize = studentsStore.count();
//   reqSize.onsuccess = () => {
//     console.log(reqSize.result);
//   }
// }

//!delete
// const request = indexedDB.open('school');
// request.onsuccess = (event) => {
//   const db = event.target.result;
//   const transaction = db.transaction("students", "readwrite");
//   const studentsStore = transaction.objectStore("students");
//   const req = studentsStore.delete(1);
//   req.onsuccess = () => console.log('deleted', req.result);
//   req.onerror = () => console.log('error: ', error.message);
// }