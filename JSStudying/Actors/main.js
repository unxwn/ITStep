const actorsList = document.querySelector('.actors-list');
const actorsSelected = document.querySelector('.actors-selected');

function createActorCard(actor) {
  const card = document.createElement('div');
  card.classList.add('actor');

  const initialsContainer = document.createElement('div');
  initialsContainer.classList.add('initials-container');
  initialsContainer.style.backgroundColor = strToColour(actor.firstName + actor.lastName);

  const initials = document.createElement('div');
  initials.classList.add('initials');
  initials.textContent = getInitials(actor.firstName, actor.lastName);

  initialsContainer.appendChild(initials);

  const img = document.createElement('img');
  img.src = actor.profilePicture || '';
  img.addEventListener('load', () => {
    initialsContainer.style.display = 'none';
  });
  img.addEventListener('error', () => {
    img.style.display = 'none';
    initialsContainer.style.display = 'flex';
  });

  const h3 = document.createElement('h3');
  h3.textContent = actor.firstName || actor.lastName ? `${actor.firstName} ${actor.lastName}` : 'Unknown';

  const contactsList = document.createElement('div');
  contactsList.classList.add('contacts-list');
  if (actor.contacts) {
    for (const link of actor.contacts) {
      icon = createIcon(link);
      if (icon) contactsList.appendChild(icon)
    }
  }

  card.appendChild(initialsContainer);
  card.appendChild(img);
  card.appendChild(h3);
  card.appendChild(contactsList);

  card.addEventListener('click', () => {
    if (actor.firstName || actor.lastName) {
      addToSelected(actor);
    } else {
      alert('Unable to add "Unknown" to list');
    }
  });

  return card;
}

function createIcon(link) {
  const icon = document.createElement('img');
  if (link.includes('instagram.com/')) {
    icon.src = 'https://cdn1.iconfinder.com/data/icons/social-media-circle-7/512/Circled_Instagram_svg-512.png';
    icon.alt = 'Instagram';
  } else if (link.includes('twitter.com/')) {
    icon.src = 'https://about.x.com/content/dam/about-twitter/x/brand-toolkit/logo-black.png.twimg.1920.png';
    icon.alt = 'Twitter';
  } else if (link.includes('facebook.')) {
    icon.src = 'https://cdn3.iconfinder.com/data/icons/social-media-black-white-2/512/BW_Facebook_glyph_svg-512.png';
    icon.alt = 'Facebook';
  }
  if (icon.src) {
    icon.addEventListener('click', (event) => {
      event.stopPropagation();
      window.open(link);
    });
    return icon;
  }
}

function getInitials(firstName, lastName) {
  if (firstName && lastName) {
    return `${firstName[0]}${lastName[0]}`.toUpperCase();
  } else if (firstName) {
    return `${firstName[0]}${firstName[0]}`.toUpperCase();
  } else if (lastName) {
    return `${lastName[0]}${lastName[0]}`.toUpperCase();
  } else {
    return 'UN';
  }
}

function strToColour(str) {
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

function addToSelected(actor) {
  const existingItems = actorsSelected.querySelectorAll('li');
  //console.log(existingItems);
  const names = Array.from(existingItems).map(item => { 
    //console.log(item.querySelector('span').textContent);
    return item.querySelector('span').textContent;
  });
  //console.log(names);

  if (!names.includes(`${actor.firstName} ${actor.lastName}`)) {
    const li = document.createElement('li');
    const span = document.createElement('span');
    span.textContent = actor.firstName || actor.lastName ? `${actor.firstName} ${actor.lastName}` : 'Unknown';

    const deleteButton = document.createElement('button');
    deleteButton.textContent = 'Delete';
    deleteButton.addEventListener('click', () => {
      li.remove();
    });

    li.appendChild(span);
    li.appendChild(deleteButton);
    actorsSelected.appendChild(li);
  }
}

actors.forEach(actor => {
  const card = createActorCard(actor);
  actorsList.appendChild(card);
});
