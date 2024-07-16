// console.log('hello');
// console.log(actors);

function createCard(actor) {
  const cardWrapper = document.createElement('li');
  cardWrapper.classList.add('card-wrapper');

  const cardContainer = document.createElement('article');
  cardContainer.classList.add('card-container');

  const cardPhoto = document.createElement('img');
  cardPhoto.classList.add('card-photo');
  cardPhoto.setAttribute('src', actor.photo);
  cardPhoto.setAttribute('alt', actor.name);

  const cardFullName = document.createElement('h2');
  cardFullName.classList.add('card-fullname');
  cardFullName.innerText = actor.name;

  const cardBirthday = document.createElement('p');
  cardBirthday.classList.add('card-birthday');
  cardBirthday.innerText = actor.birthdate;

  cardContainer.append(cardPhoto, cardFullName, cardBirthday);

  cardWrapper.append(cardContainer);//li -> article

  return cardWrapper;
}

const cardsList = document.getElementById('cards-list');

const HTMLCards = actors.map(actor => createCard(actor));
cardsList.append(...HTMLCards);