import './App.css';

function App() {
  return (
    <div className="App">
      <div className="my-photo">
        <img
          src="https://thispersondoesnotexist.com/"
          alt="My face"
          className="profile-photo"
        />
      </div>
      <div className="info">
        <h1>
          Поліщук
          <br></br>
          Мирослав
          <br></br>
          Ігорьович</h1>
        <p>Контактний телефон: +380936743290</p>
        <p>Електронна адреса: example@dom.bom</p>
      </div>
    </div>
  );
}

export default App;
