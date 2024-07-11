import React from 'react';
import './ChurchInfo.css';
import churchImage from './Church.jpg';
import bellTower from './Bell.jpg';

const ChurchInfo = () => {
  return (
    <div className="church-info">
      <img src={churchImage} alt="Church" className="church-image" />
      <div className="church-description">
        <h2>Церква Покрови Пресвятої Богородиці</h2>
        <ul>
          <li>Церква Покрови Пресвятої Богородиці із чудотворною іконою Іоана Хрестителя (1913), при церкві є дзвіниця (1730).</li>
          <li>Встановлено 3 козацькі хрести.</li>
          <li>Споруджено пам'ятник полеглим у німецько-радянській війні воїнам-односельцям (1973).</li>
        </ul>
      </div>
      <img src={bellTower} alt='Bell' className='bell-tower-image' />
    </div>
  );
};

export default ChurchInfo;
