const slider = document.querySelector('.slider');
const prevButton = document.querySelector('.prev-button');
const nextButton = document.querySelector('.next-button');
const playStopButton = document.querySelector('.play-stop-button');
const shuffleButton = document.querySelector('.shuffle-button');
const scaleSlider = document.querySelector('#scale-slider');
const scaleValue = document.querySelector('#scale-value');

const pauseTime = 3000;
let pictures = [];
let currentIndex = 0;
let interval;
let isPlaying = false;

fetch("https://randomuser.me/api/?results=5000")
  .then(response => response.json())
  .then(data => {
    pictures = data.results.map(user => user.picture.large);
    initializeSlides();
  })
  .catch(error => console.log("Error fetching data:", error));

function initializeSlides() {
  slider.innerHTML = '';
  pictures.forEach((picture, index) => {
    const slide = document.createElement('div');
    slide.className = 'slide';
    const img = document.createElement('img');
    img.src = picture;
    img.alt = `Slide ${index + 1}`;
    slide.appendChild(img);
    slider.appendChild(slide);
  });
  setSlide(0);
}

function setSlide(index) {
  currentIndex = index;
  slider.style.transform = `translateX(${-index * 100}%)`;
}

function nextSlide() {
  currentIndex = (currentIndex + 1) % pictures.length;
  setSlide(currentIndex);
}

function prevSlide() {
  currentIndex = (currentIndex - 1 + pictures.length) % pictures.length;
  setSlide(currentIndex);
}

function startSlider() {
  interval = setInterval(nextSlide, pauseTime);
}

function stopSlider() {
  clearInterval(interval);
}

function togglePlayStop() {
  if (isPlaying) {
    stopSlider();
    playStopButton.textContent = "Play";
  } else {
    startSlider();
    playStopButton.textContent = "Stop";
  }
  isPlaying = !isPlaying;
}

function shuffleSlides() {
  pictures.sort(() => Math.random() - 0.5);
  initializeSlides();
  setSlide(0);
}

function updateScale() {
  const scale = scaleSlider.value;
  scaleValue.textContent = `${scale}x`;
  const images = document.querySelectorAll('.slide img');
  images.forEach(img => {
    img.style.transform = `scale(${scale})`;
  });
}

nextButton.addEventListener('click', nextSlide);
prevButton.addEventListener('click', prevSlide);
playStopButton.addEventListener('click', togglePlayStop);
shuffleButton.addEventListener('click', () => {
  stopSlider();
  shuffleSlides();
  if (isPlaying) {
    startSlider();
  }
});
scaleSlider.addEventListener('input', updateScale);
