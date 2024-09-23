//todo графіка; збільшення довжини рівня; виправлення режиму hardcore;
//todo "розумна" генерація мін; звук;
const canvas = document.getElementById('gameCanvas');
const context = canvas.getContext('2d');

const tileWidth = 50;
const tileHeight = 50;
const playerSize = 0.8 * tileWidth;
const rows = 14;
const cols = 7;

let gameTimer;
let timeoutId;
let level = 1;
let lives = 3;
let eyes = 3;
let difficulty = 'Training';
let player = { x: 0, y: 0, width: playerSize, height: playerSize, speed: tileWidth };
let tiles = [];
let bonuses = [];
let gameStarted = false;
let isGameOver = false;
let showMines = true;
let xrayActive = false;

const xrayImage = new Image();
xrayImage.src = './xray.png';

const heartImage = new Image();
heartImage.src = './heart.png';

const unminerImage = new Image();
unminerImage.src = './unminer.png';

const createTiles = () => {
  tiles = [];
  for (let r = 0; r < rows; r++) {
    const row = [];
    for (let c = 0; c < cols; c++) {
      const isMine = r != 0 && r != rows - 1 && Math.random() < 0.2;
      const color = isMine ? '#ff0000' : r == 0 || r == rows - 1 ? c == 3 && r != 0 ? '#006400' : '#eeff00' : '#00ff00';
      row.push({ x: c * tileWidth, y: r * tileHeight, isMine, color, revealed: false, discovered: false });
    }
    tiles.push(row);
  }
};

const createBonuses = () => {
  bonuses = [];
  let heartsCount = Math.random() < 0.5 ? 1 : 0;
  let xraysCount = Math.random() < 0.5 ? (Math.random() < 0.3 ? 2 : 1) : 0;

  while (heartsCount > 0) {
    let r = Math.floor(Math.random() * (rows - 2)) + 1;
    let c = Math.floor(Math.random() * cols);

    if (!tiles[r][c].isMine) {
      bonuses.push({ x: c * tileWidth, y: r * tileHeight, type: 'heart' });
      heartsCount--;
    }
  }

  while (xraysCount > 0) {
    let r = Math.floor(Math.random() * (rows - 7) + 1);
    let c = Math.floor(Math.random() * cols);

    if (!tiles[r][c].isMine) {
      bonuses.push({ x: c * tileWidth, y: r * tileHeight, type: 'xray' });
      xraysCount--;
    }
  }
};

const drawTiles = () => {
  tiles.forEach((row, r) => {
    row.forEach(tile => {
      if (tile.revealed && tile.isMine) {
        context.fillStyle = '#ff0000';
      } else if (tile.darkened) {
        context.fillStyle = '#006400';
      } else {
        context.fillStyle = tile.color;
      }
      context.fillRect(tile.x, tile.y, tileWidth, tileHeight);

      if (r !== 0 && r !== rows - 1) {
        context.strokeStyle = '#000';
        context.strokeRect(tile.x, tile.y, tileWidth, tileHeight);
      }
    });
  });
};

const drawBonuses = () => {
  bonuses.forEach(bonus => {
    const image = bonus.type === 'xray' ? xrayImage : heartImage;
    context.drawImage(image, bonus.x + (tileWidth - tileWidth * 0.8) / 2, bonus.y + (tileHeight - tileHeight * 0.8) / 2, tileWidth * 0.8, tileHeight * 0.8);
  });
};

const activateXray = () => {
  if (eyes > 0 && !xrayActive) {
    eyes--;
    xrayActive = true;
    revealMines(true);
    setTimeout(() => {
      xrayActive = false;
      revealMines(false);
    }, 500);
    updateUI();
  }
};

const revealMines = (toShow = true) => {
  tiles.forEach(row => {
    row.forEach(tile => {
      if (tile.isMine) {
        tile.revealed = toShow;
      }
    });
  });
  update();
};

const checkTile = () => {
  const tileX = Math.floor(player.x / tileWidth);
  const tileY = Math.floor(player.y / tileHeight);
  const currentTile = tiles[tileY][tileX];

  if (!currentTile.isMine) {
    if (!currentTile.darkened) {
      currentTile.color = '#006400';
      currentTile.darkened = true;
    }
  }

  if (currentTile.isMine) {
    lives--;
    if (lives === 0) {
      endGame();
    } else {
      showMines = true;
      currentTile.revealed = true;
      resetPlayer();
      updateUI();
    }
  }
};

const checkBonus = () => {
  const tileX = Math.floor(player.x / tileWidth);
  const tileY = Math.floor(player.y / tileHeight);

  bonuses = bonuses.filter(bonus => {
    if (bonus.x === tileX * tileWidth && bonus.y === tileY * tileHeight) {
      if (bonus.type === 'xray' && eyes < 8) eyes++;
      if (bonus.type === 'heart' && lives < 3) lives++;
      return false;
    }
    return true;
  });
  updateUI();
};

const checkFinish = () => {
  if (player.y <= 50) {
    level++;
    createTiles();
    createBonuses();
    resetPlayer();
    updateUI();
    gameStarted = false;
  }
};

const drawPlayer = () => {
  context.fillStyle = 'blue';
  //context.fillRect(player.x, player.y, player.width, player.height);
  context.drawImage(unminerImage, player.x - 2, player.y - 3, player.width, player.height)
};

const movePlayer = (event) => {
  if (isGameOver || !gameStarted) return;

  const prevX = player.x;
  const prevY = player.y;

  if (event.key === 'ArrowLeft' && player.x > 0) player.x -= player.speed;
  if (event.key === 'ArrowRight' && player.x + player.width < canvas.width) player.x += player.speed;
  if (event.key === 'ArrowUp' && player.y > 0) player.y -= player.speed;
  if (event.key === 'ArrowDown' && player.y + player.height < canvas.height) player.y += player.speed;

  if (player.x < 0) player.x = prevX;
  if (player.x + player.width > canvas.width) player.x = prevX;
  if (player.y < 0) player.y = prevY;
  if (player.y + player.height > canvas.height) player.y = prevY;

  checkTile();
  checkFinish();
  checkBonus();
};

const resetPlayer = () => {
  player.x = ((cols / 2) * tileWidth) - 15;
  player.y = canvas.height - 39;
};

const drawLives = () => {
  const livesContainer = document.getElementById('livesContainer');
  livesContainer.innerHTML = '';
  if (lives == 0) {
    const img = document.createElement('img');
    img.style.height = '32px';
    livesContainer.appendChild(img);
    return;
  }
  for (let i = 0; i < lives; i++) {
    const img = document.createElement('img');
    img.src = './heart.png';
    img.style.width = '32px';
    img.style.height = '32px';
    img.style.marginRight = '10px';
    livesContainer.appendChild(img);
  }
};

const drawEyes = () => {
  const eyesContainer = document.getElementById('eyesContainer');
  eyesContainer.innerHTML = '';
  if (eyes == 0) {
    const img = document.createElement('img');
    img.style.height = '48px';
    eyesContainer.appendChild(img);
    return;
  }
  for (let i = 0; i < eyes; i++) {
    const img = document.createElement('img');
    img.src = './xray.png';
    img.style.width = '48px';
    img.style.height = '48px';
    img.style.marginRight = '6px';
    eyesContainer.appendChild(img);
  }
};

const drawCenteredText = (text, y) => {
  context.fillStyle = 'black';
  context.font = '18px Arial';
  const textWidth = context.measureText(text).width;
  const x = (canvas.width - textWidth) / 2;
  context.fillText(text, x, y);
};

const updateUI = () => {
  document.getElementById('info').innerText = `Level: ${level} | Difficulty: ${difficulty}`;
  drawLives();
  drawEyes();
};

const update = () => {
  context.clearRect(0, 0, canvas.width, canvas.height);
  drawTiles();
  drawBonuses();
  drawPlayer();

  if (!gameStarted && difficulty === 'Training') {
    drawCenteredText('Remember the placement of the mines', 20);
    drawCenteredText('and click "s"', 40);
  }

  if (xrayActive) {
    showMines = true;
  } else {
    showMines = difficulty === 'Training' && !gameStarted;
  }
};

const endGame = () => {
  clearInterval(gameTimer);

  revealMines();

  context.fillStyle = 'rgba(0, 0, 0, 0.5)';
  context.fillRect(0, 0, canvas.width, canvas.height);
  drawCenteredText('You lost', canvas.height / 2);

  setTimeout(() => {
    level = 1;
    lives = 3;
    eyes = 3;
    createTiles();
    createBonuses();
    resetPlayer();
    updateUI();
    gameStarted = false;
    isGameOver = false;
    startLevel();
  }, 2000);
};

const startLevel = () => {
  clearInterval(gameTimer);
  createTiles();
  createBonuses();
  updateUI();
  resetPlayer();
  showMines = (difficulty === 'Training');

  if (difficulty === 'Hardcore') {
    setTimeout(() => {
      showMines = false;
      update();
    }, 2000);
  }

  gameTimer = setInterval(update, 15);
};

const startGame = () => {
  startLevel();
  initializeEventListeners();
};

const initializeEventListeners = () => {
  document.addEventListener('keydown', movePlayer);
  document.addEventListener('keydown', (event) => {
    if (/^[vVмМ]$/.test(event.key)) {
      activateXray();
    }

    if (difficulty === 'Training') {
      if (/^[sSіІ]$/.test(event.key)) {
        gameStarted = true;
        showMines = false;
        tiles.forEach(row => row.forEach(tile => {
          if (tile.color === '#ff0000') {
            tile.color = '#00ff00';
          }
        }));
        update();
      }
    }
  });

  document.getElementById('difficultyBtn').addEventListener('click', () => {
    if (!gameStarted) {
      if (difficulty === 'Training') {
        difficulty = 'Hardcore';
        document.getElementById('difficultyBtn').innerText = 'Switch to Training';
      } else {
        difficulty = 'Training';
        document.getElementById('difficultyBtn').innerHTML = 'Hardcore <br> (does not work)';
      }

      startLevel();
    } else {
      const btn = document.getElementById('difficultyBtn');
      btn.innerText = 'You`ve started lvl';
      btn.style.color = 'red';

      if (timeoutId) {
        clearTimeout(timeoutId);
      }
      timeoutId = setTimeout(() => {
        btn.style.color = 'white';
        if (difficulty === 'Training') {
          document.getElementById('difficultyBtn').innerHTML = 'Hardcore <br> (does not work)';
        } else {
          document.getElementById('difficultyBtn').innerText = 'Switch to Training';
        }
      }, 2000);
    }
  });


  document.getElementById('regenFieldBtn').addEventListener('click', () => {
    if (!gameStarted) {
      createTiles();
      createBonuses();
      update();
    } else {
      const btn = document.getElementById('regenFieldBtn');
      btn.innerText = 'You`ve started lvl';
      btn.style.color = 'red';

      if (timeoutId) {
        clearTimeout(timeoutId);
      }
      timeoutId = setTimeout(() => {
        btn.style.color = 'white';
        btn.innerText = 'Regenerate field';
      }, 2000);
    }
  });
};

startGame();