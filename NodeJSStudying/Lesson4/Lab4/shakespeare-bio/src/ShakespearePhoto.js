import React from 'react';
import './ShakespearePhoto.css';

class ShakespearePhoto extends React.Component {
  render() {
    return (
      <div className="shakespeare-photo">
        <img
          src="https://upload.wikimedia.org/wikipedia/commons/a/a2/Shakespeare.jpg"
          alt="William Shakespeare"
        />
      </div >
    );
  }
};

export default ShakespearePhoto;
