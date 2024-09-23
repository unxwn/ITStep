//!canvas
const canvas = document.getElementById("canvas");
const context = canvas.getContext("2d");

// fillRect(x, y, w, h): заливає кольором прямокутник
// strokeRect(x, y, w, h): малює контур прямокутника без заливки
// clearRect(x, y, w, h): очищає певну прямокутну область

// context.fillRect(10, 10, 100, 100);
// context.strokeRect(20, 20, 100, 100);
// context.clearRect(0, 0, 50, 50);

// context.fillRect(10, 10, 100, 100);
// context.clearRect(15, 15, 90, 90);

// context.fillRect(10, 10, 80, 80);
// context.clearRect(20, 20, 60, 20);    
// context.fillRect(30, 25, 10, 10);
// context.fillRect(60, 25, 10, 10);  
// context.clearRect(25, 60, 50, 10);

// strokeStyle: встановлює колір ліній або колір контуру. За замовчуванням встановлено чорний колір
// fillStyle: встановлює колір заповнення фігур. За замовчуванням встановлено чорний колір
// lineWidth: встановлює товщину ліній. За замовчуванням дорівнює 1.0
// lineJoin: встановлює стиль з’єднання ліній
// globalAlpha: встановлює прозорість відтворення на canvas
// setLineDash: створює лінію з коротких штрихів

//!колір контуру або межі
// context.strokeStyle = "#ff0000";     // встановлюємо колір контуру фігури
// context.strokeRect(10, 10, 100, 100);

// context.fillStyle = "#ee5253";     // встановлюємо колір заповнення фігури
// context.fillRect(10, 10, 100, 100);

// context.fillStyle = "#c7ecee";     // встановлюємо колір заповнення фігури
// context.fillRect(10, 10, 100, 100);
// context.strokeStyle = "#22a6b3";     // встановлюємо колір контуру фігури
// context.strokeRect(10, 10, 100, 100);
// context.fillRect(120, 10, 100, 100);       // прямокутник без межі
// context.strokeRect(230, 10, 100, 100);     // прямокутник без заповнення

//!Товщина ліній
// context.fillStyle = "#c7ecee";     // встановлюємо колір заповнення фігури
// context.fillRect(10, 10, 100, 100);
// context.strokeStyle = "#22a6b3";     // встановлюємо колір контуру фігури
// context.lineWidth = 1;             // встановлюємо товщину лінії
// context.strokeRect(10, 10, 100, 100);

// context.fillStyle = "#c7ecee";     // встановлюємо колір заповнення фігури
// context.fillRect(10, 130, 100, 100);
// context.strokeStyle = "#22a6b3";     // встановлюємо колір контуру фігури
// context.lineWidth = 10;             // встановлюємо товщину лінії
// context.strokeRect(10, 130, 100, 100);

//!Тип з’єднання ліній
// context.strokeStyle = "red";
// context.lineWidth = 10;
// context.lineJoin = "miter";//прямі з’єднання, які утворюють прямі кути.
// context.strokeRect(10, 10, 100, 100);
// context.lineJoin = "bevel";//конічні з’єднання
// context.strokeRect(130, 10, 100, 100);
// context.lineJoin = "round";//закруглені з’єднання
// context.strokeRect(250, 10, 100, 100);

//!Прозорість
// context.fillStyle = "blue";
// context.fillRect(50, 50, 100, 100);
// context.globalAlpha = 0.5;
// context.fillStyle = "red";
// context.fillRect(100, 100, 100, 100);

//!лінія з коротких штрихів
// context.strokeStyle = "green";
// context.setLineDash([10]);
// context.strokeRect(250, 10, 100, 100);
// context.strokeStyle = "red";
// context.setLineDash([20,5]);
// context.strokeRect(10, 10, 100, 100);               

//!Фонові зображення
// repeat: зображення повторюється для заповнення всього простору фігури
// repeat-x: зображення повторюється лише по горизонталі
// repeat-y: зображення повторюється лише по вертикалі
// no-repeat: зображення не повторюється

// const img = new Image();
// img.src = "square.jpg";
// img.onload = () => {
//   const pattern = context.createPattern(img, "repeat");
//   context.fillStyle = pattern;
//   context.fillRect(10, 10, 500, 500);
//   context.strokeRect(10, 10, 500, 500);
// };

//!Лінійний градієнт
//createLinearGradient(x0, y0, x1, y1), де x0 і y0 - це початкові координати градієнта
//addColorStop(offset, color), де offset - це зміщення точки градієнта, а color - її колір
// const gradient = context.createLinearGradient(50, 30, 150, 150);
// gradient.addColorStop(0, "blue");       // від синього кольору
// gradient.addColorStop(1, "white");      // до білого кольору
// context.fillStyle = gradient;           // як колір заповнення встановлюємо градієнт
// context.fillRect(50, 30, 150, 150);
// context.strokeRect(50, 30, 150, 150);
// const gradient = context.createLinearGradient(0, 0, 150, 150);
// const gradient = context.createLinearGradient(50, 30, 50, 150);//вертикальний
// const gradient = context.createLinearGradient(50, 30, 150, 30);//горизонтальний
// gradient.addColorStop(0, "blue");       // від білого кольору
// gradient.addColorStop(0.5, "green");    // до зеленого кольору
// gradient.addColorStop(1, "red");      // до синього кольору
// context.fillStyle = gradient; 
// context.fillRect(50, 30, 150, 150);
// context.strokeRect(50, 30, 150, 150);

//!Радіальний градієнт
// createRadialGradient(x0, y0, r0, x1, y1, r1)
// x0 і y0: координати центру першого кола
// r0: радіус першого кола
// x1 і y1: координати центру другого кола
// r1: радіус другого кола
// const gradient = context.createRadialGradient(120, 100, 100, 120, 100, 30);
// gradient.addColorStop(0, "blue");
// gradient.addColorStop(1, "white");
// context.fillStyle = gradient;
// context.fillRect(50, 30, 150, 150);
// context.strokeRect(50, 30, 150, 150);

//!Малювання тексту
// fillText(text, x, y): приймає три параметри: текст, який виводиться (параметр text) і
// координати точки, з якої виводиться текст (параметри x і y).
// strokeText(text, x, y): приймає аналогічні параметри.
// fillText() використовує колір заповнення фігури (із властивості fillStyle)
// і заповнює ним символи тексту.
// strokeText() використовує колір контуру фігури (задається через властивість strokeStyle) і
// малює контур символів.
// context.font = "30px Verdana";
// context.fillStyle = "red";     // встановлюємо колір тексту
// context.fillText("Hello World", 20, 50);
// context.font = "30px Verdana";
// context.strokeStyle = "red";     // встановлюємо колір тексту
// context.strokeText("Hello World", 20, 50);

//!Властивість textAlign
// right: текст закінчується до вказаної позиції
// left: текст починається з вказаної позиції
// center: текст розташовується по центру відносно вказаної позиції
// start: значення за замовчуванням, текст починається з вказаної позиції
// end: текст закінчується до вказаної позиції
// context.font = "22px Verdana";
// context.textAlign = "right";
// context.fillText("Right Text", 120, 30);
// context.textAlign = "left";
// context.fillText("Left Text", 120, 60);
// context.textAlign = "center";
// context.fillText("Center Text", 120, 90);
// context.textAlign = "start";
// context.fillText("Start Text", 120, 120);
// context.textAlign = "end";
// context.fillText("End Text", 120, 150);

//!Малювання фігур
// context.beginPath();//Для створення нового шляху
// context.moveTo(20, 100);
// context.lineTo(140, 10);
// context.lineTo(360, 100);
// context.lineTo(20, 100);
// // context.closePath();    //  закриваємо шлях
// context.stroke();       // відображаємо шлях
// context.beginPath();
// context.moveTo(50, 300);
// context.lineTo(140, 50);
// context.strokeStyle = "red";
// context.stroke();       // відображаємо шлях

//!Об'єкти Path2D
// const path1 = new Path2D();     // перший шлях
// path1.moveTo(20, 100);
// path1.lineTo(140, 10);
// path1.lineTo(260, 100);
// path1.closePath();    //  закриваємо шлях
// context.strokeStyle = "blue";
// context.stroke(path1);
// const path2 = new Path2D();     // другий шлях
// path2.moveTo(20, 110);
// path2.lineTo(140, 200);
// path2.lineTo(260, 110);
// path2.closePath();    //  закриваємо шлях
// context.strokeStyle = "red";
// context.stroke(path2);

//!Метод rect
// rect(x, y, width, height)
// x і y - це координати верхнього лівого кута прямокутника відносно canvas,
// width і height - відповідно ширина і висота прямокутника.
// context.beginPath();
// context.rect(30, 20, 100, 150);
// context.stroke();
// context.beginPath();
// context.rect(200, 200, 50, 50);
// context.stroke();

// можна створити з ліній
// context.beginPath();
// context.moveTo(30, 20);
// context.lineTo(130, 20);
// context.lineTo(130, 110);
// context.lineTo(30, 110);
// context.closePath();
// context.stroke();

//! fill() заповнює кольором весь внутрішній простір намальованого шляху
// context.beginPath();
// context.moveTo(20, 100);
// context.lineTo(140, 10);
// context.lineTo(260, 100);
// context.closePath();
// context.strokeStyle = "red";
// context.fillStyle = "#4bcffa";
// context.fill();
// context.stroke();

//!arc() додає до шляху ділянку кола або дугу/арку
// arc(x, y, radius, startAngle, endAngle, anticlockwise)
// x і y: x- і y-координати, в яких починається дуга
// radius: радіус кола, за яким створюється дуга
// startAngle і endAngle: початковий і кінцевий кут, які відсікають коло до дуги.
// В якості одиниці вимірювання для кутів застосовуються радіани.
// Наприклад, повне коло - це 2π радіан. Якщо, наприклад, потрібно намалювати повне коло,
// то для параметра endAngle можна вказати значення 2π.
// У JavaScript цю величину можна отримати за допомогою виразу Math.PI * 2.
// anticlockwise: напрямок руху по колу при відсіченні його частини,
// обмеженої початковим і кінцевим кутом. При значенні true напрямок проти годинникової стрілки,
// а при значенні false - за годинниковою стрілкою.
// context.strokeStyle = "red";

// context.beginPath();
// context.moveTo(20, 90);
// context.arc(20, 90, 50, 0, Math.PI / 2, false);
// context.closePath();
// context.stroke();

// context.beginPath();
// context.moveTo(130, 90);
// context.arc(130, 90, 50, 0, Math.PI, false);
// context.closePath();
// context.stroke();

// context.beginPath();
// context.arc(240, 90, 50, 0, Math.PI * 2, false);
// context.closePath();
// context.stroke();

// anticlockwise відіграє важливу роль, оскільки визначає рух по колу,
// і в разі зміни true на false і навпаки, можна отримати зовсім різні фігури:
// context.strokeStyle = "red";

// context.beginPath();
// context.moveTo(80, 90);
// context.arc(80, 90, 50, 0, Math.PI / 2, false);
// context.closePath();
// context.stroke();

// context.beginPath();
// context.moveTo(240, 90);
// context.arc(240, 90, 50, 0, Math.PI / 2, true);
// context.closePath();
// context.stroke();
