import React from 'react';
import { BrowserRouter as Router, Route, NavLink, Routes, useParams } from 'react-router-dom';
import './App.css';

function Bio() {
  return (
    <div>
      <h2>Bio</h2>
      <img src="https://thispersondoesnotexist.com" alt="Artist" className="artist-image" />
      <p>Bio Page</p>
    </div>
  );
}

function FamousPaintings() {
  return (
    <div>
      <h2>Famous Painting</h2>
      <img src="https://thispersondoesnotexist.com" alt="Famous Painting" className="artist-image" />
      <p>Famous Painting Page</p>
    </div>
  );
}

function Gallery() {
  return (
    <div>
      <h2>Gallery</h2>
      <img src="https://thispersondoesnotexist.com" alt="Gallery" className="artist-image" />
      <p>Gallery Page</p>
    </div>
  );
}

function ShowParam() {
  const { param } = useParams();
  return (
    <div>
      <h2>Received Parameter</h2>
      <p>Parameter: {param}</p>
    </div>
  );
}

function NotFound() {
  return <p>Page not found</p>;
}

function App() {
  return (
    <Router>
      <div className="navbar">
        <NavLink to="/" className="nav-link">Bio</NavLink>
        <NavLink to="/famous-paintings" className="nav-link">Famous Paintings</NavLink>
        <NavLink to="/gallery" className="nav-link">Gallery</NavLink>
        <NavLink to="/show-param/example" className="nav-link">Show Param</NavLink>
      </div>

      <div className="content">
        <Routes>
          <Route path="/" element={<Bio />} />
          <Route path="/famous-paintings" element={<FamousPaintings />} />
          <Route path="/gallery" element={<Gallery />} />
          <Route path="/show-param/:param" element={<ShowParam />} />
          <Route path="*" element={<NotFound />} />
        </Routes>
      </div>
    </Router>
  );
}

export default App;
