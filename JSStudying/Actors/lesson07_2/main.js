const cardsList = document.getElementById('cards-list');
const HTMLCards = actors
  .filter((actor) => actor.name && actor.photo)
  .map((actor) => createCard(actor));



function createCard(actor) {
  return createElement('li', { classNames: ['card-wrapper'] },
    createElement('article', { classNames: ['card-container'] },
      createWrapper(actor),
      createElement('h2',
        {
          classNames: ['card-fullname'],
          click: () => console.log(actor.birthdate)
        },
        actor.name
      ),
      createElement('p', { classNames: ['card-birthday'] },
        document.createTextNode(actor.birthdate)
      )
    )
  );
}

function stringToColour(str) {
  let hash = 0;
  for (let i = 0; i < str.length; i++) {
    hash = str.charCodeAt(i) + ((hash << 5) - hash);
  }
  let colour = '#';
  for (let i = 0; i < 3; i++) {
    let value = (hash >> (i * 8)) & 0xFF;
    colour += ('00' + value.toString(16)).slice(-2);
  }
  return colour;
}


function createElement(tag, { classNames, click }, ...children) {
  const element = document.createElement(tag);
  element.classList.add(...classNames);
  element.addEventListener('click', click);
  element.append(...children);
  return element;
}

function createWrapper(actor) {
  const cardPhotoWrapper = document.createElement('div');
  cardPhotoWrapper.classList.add('card-photo-wrapper');
  cardPhotoWrapper.setAttribute('id', `wrapper-${actor.id}`);

  const cardInitials = document.createElement('div');
  cardInitials.classList.add('card-initials');
  cardInitials.innerText = actor.name[0] || 'unknown';
  cardInitials.style.backgroundColor = stringToColour(actor.name);

  createImage(actor);
  cardPhotoWrapper.append(cardInitials);

  return cardPhotoWrapper;
}

function createImage(actor) {
  const cardPhoto = document.createElement('img');
  cardPhoto.classList.add('card-photo');
  cardPhoto.setAttribute('src', actor.photo);
  cardPhoto.setAttribute('alt', actor.name);
  cardPhoto.dataset.wrapperId = `wrapper-${actor.id}`;
  cardPhoto.addEventListener('error', photoErrorHandler);
  cardPhoto.addEventListener('load', photoLoadHandler);
}

function photoLoadHandler({ target }) {
  //console.log(target);//поместить в cardPhotoWrapper???
  // console.log(target.parentElement);
  const parent = document.getElementById(target.dataset.wrapperId);
  parent.append(target);
}


function photoErrorHandler({ target }) {
  // console.log(target);
  // console.dir(target);
  target.remove();
}
cardsList.append(...HTMLCards);
