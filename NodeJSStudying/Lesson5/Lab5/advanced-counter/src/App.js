import ControlConfig from './ControlConfig';
import { useState } from 'react';
import './App.css';

function ControlMenu(props) {
  const changeState = (event) => {
    props.onClickAct(prevCount => prevCount + parseInt(event.target.value));
  }

  return (Object.values(props.cfg).map(el =>
    <button value={el} onClick={changeState}>{el}</button>));
}

function App() {
  const [count, setCount] = useState(0);

  return (
    <div className='App'>
      <ControlMenu cfg={ControlConfig} onClickAct={setCount} />
      <h2 className='test'>Count:<br />{count}</h2>
    </div>
  );
}

export default App;