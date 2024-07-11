import React from 'react';
import './Header.css';
import VillageImage from './Lake.jpg';

const Header = () => {
  return (
    <div className="header">
      <img src={VillageImage} alt="Lake view" className="lake-image" />
    </div>
  );
};

export default Header;
