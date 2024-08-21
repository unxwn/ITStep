import React from 'react';
import { BrowserRouter as Router, Route, Routes, Outlet } from 'react-router-dom';
import Navbar from './Navbar';
import CityInfo from './CityInfo';
import FamousLandmark from './FamousLandmark';
import OtherLandmarks from './OtherLandmarks';
import CityPhotos from './CityPhotos';
import './App.css';

function App() {
  return (
    <Router>
      <Navbar />
      <Routes>
        <Route path="/" element={<CityInfo />} />
        <Route path="/landmark" element={<FamousLandmark />} />
        <Route path="/other-landmarks" element={<OtherLandmarks />} />
        <Route path="/photos" element={<CityPhotos />} />
        <Route path="/*" element={<Error />} />
      </Routes>
    </Router>
  );
}

function Error() {
  return (
    <div>
      <h2>Errrrrror</h2>
    </div>
  );
}

export default App;
