import React from 'react';
import BandImg from './BandImg.png';

class BandInfo extends React.Component {
  render() {
    return (
      <>
        <div>
          <img src={BandImg} alt='Band' className='band-img' />
          <h1>Улюблена музична група</h1>
          <h1>На Відміну Від</h1>
          <h3>Жанри: реп, хіп-хоп</h3>
          <h3>Роки: 2005 — 2014</h3>
          <h3>Учасники:</h3>
          <ul>
            <li>Андрій Шалімов — «Фріл»</li>
            <li>Андрій Бєляєв — «Бєляєв»</li>
          </ul>
          <h3>Дискографія:</h3>
          <h4>Альбоми:</h4>
          <ul>
            <li>Я боюся Чебурашку (2007)</li>
            <li>Врубайся! (2009)</li>
            <li>Новий альбом (2015)</li>
          </ul>
          <h4>Сингли:</h4>
          <ul>
            <li>Збираю речі (2009)</li>
            <li>Шукай мене (2009)</li>
            <li>Як буде (2009)</li>
            <li>Обійми мене (2010; разом з Ділею)</li>
            <li>Тянет (2013)</li>
          </ul>
          <h4>Кліпи:</h4>
          <ul>
            <li>Обійми мене (2011; разом з Ділею)</li>
            <li>2012 (2012)</li>
            <li>Канцик (2012)</li>
            <li>2012 (російська версія) (2012)</li>
            <li>Продались москалям (2012)</li>
            <li>Тянет (2013)</li>
          </ul>
        </div>
      </>
    );
  }
}

export default BandInfo;