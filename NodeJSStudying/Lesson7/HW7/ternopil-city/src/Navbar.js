import React from 'react';
import { NavLink } from 'react-router-dom';
import './Navbar.css';

function Navbar() {
  return (
    <div className="navbar">
      <NavLink to="/" className="nav-link">About City</NavLink>
      <NavLink to="/landmark" className="nav-link">Famous Landmark</NavLink>
      <NavLink to="/other-landmarks" className="nav-link">Other Landmarks</NavLink>
      <NavLink to="/photos" className="nav-link">City Photos</NavLink>
    </div>
  );
}

export default Navbar;
