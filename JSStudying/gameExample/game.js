const canvas = document.getElementById('gameCanvas');
const ctx = canvas.getContext('2d');

// Гравець - це зелений квадрат, яким керує користувач.
const player = {
    x: canvas.width / 2 - 15,  // Початкова позиція по осі X
    y: canvas.height - 30,     // Початкова позиція по осі Y
    width: 40,                 // Ширина квадрата гравця
    height: 40,                // Висота квадрата гравця
    color: '#00ff00',          // Колір квадрата гравця
    dx: 5                      // Крок руху по осі X
};

// Масив для зберігання перешкод
const obstacles = [];
const obstacleWidth = 30;      // Ширина перешкоди
const obstacleHeight = 30;     // Висота перешкоди
const obstacleSpeed = 3;       // Швидкість падіння перешкод
let gameInterval;              // Інтервал для оновлення гри
let isGameOver = false;        // Прапорець, що відображає стан гри (закінчена чи ні)

// Функція для відображення гравця на екрані
function drawPlayer() {
    ctx.fillStyle = player.color;
    ctx.fillRect(player.x, player.y, player.width, player.height);
}

// Функція для відображення перешкоди на екрані
function drawObstacle(obstacle) {
    ctx.fillStyle = obstacle.color;
    ctx.fillRect(obstacle.x, obstacle.y, obstacleWidth, obstacleHeight);
}

// Функція для створення нової перешкоди
function createObstacle() {
    const x = Math.random() * (canvas.width - obstacleWidth);  // Випадкова позиція по осі X
    const color = '#' + Math.floor(Math.random() * 16777215).toString(16);  // Випадковий колір
    obstacles.push({ x, y: 0, color });  // Додаємо перешкоду до масиву
}

// Функція для оновлення позицій перешкод
function updateObstacles() {
    obstacles.forEach((obstacle, index) => {
        obstacle.y += obstacleSpeed;  // Переміщуємо перешкоду вниз
        if (obstacle.y + obstacleHeight > canvas.height) {  // Якщо перешкода вийшла за межі екрану
            obstacles.splice(index, 1);  // Видаляємо її з масиву
        }
    });
}

// Функція для перевірки зіткнення гравця з перешкодою
function checkCollision() {
    for (let i = 0; i < obstacles.length; i++) {
        const obstacle = obstacles[i];
        if (
            player.x < obstacle.x + obstacleWidth &&
            player.x + player.width > obstacle.x &&
            player.y < obstacle.y + obstacleHeight &&
            player.y + player.height > obstacle.y
        ) {
            isGameOver = true;  // Якщо зіткнення відбулося, гра закінчується
            clearInterval(gameInterval);  // Зупиняємо оновлення гри
            alert('Гра закінчена!');  // Виводимо повідомлення
        }
    }
}

// Функція для руху гравця вліво або вправо
function movePlayer(event) {
    if (event.key === 'ArrowLeft' && player.x > 0) {  // Якщо натиснута ліва стрілка
        player.x -= player.dx;  // Рух вліво
    }
    if (event.key === 'ArrowRight' && player.x + player.width < canvas.width) {  // Якщо натиснута права стрілка
        player.x += player.dx;  // Рух вправо
    }
}

// Функція для малювання всіх елементів на екрані
function draw() {
    ctx.clearRect(0, 0, canvas.width, canvas.height);  // Очищаємо екран
    drawPlayer();  // Малюємо гравця
    obstacles.forEach(drawObstacle);  // Малюємо всі перешкоди
}

// Функція для оновлення стану гри
function update() {
    if (!isGameOver) {
        updateObstacles();  // Оновлюємо позиції перешкод
        checkCollision();   // Перевіряємо на зіткнення
        draw();             // Малюємо всі елементи на екрані
    }
}

// Функція для запуску гри
function startGame() {
    gameInterval = setInterval(() => {
        update();  // Оновлюємо стан гри
        if (Math.random() < 0.1) {  // З імовірністю 10% створюємо нову перешкоду
            createObstacle();
        }
    }, 100);  // Оновлення кожні 100 мілісекунд
}

// Слухач подій для обробки натискань клавіш
document.addEventListener('keydown', movePlayer);

// Початок гри
startGame();