import './App.css';
import React from 'react';

class Button extends React.Component {
  mouseHoverHandler = () =>
    this.props.onHoverAct(this.props.bkColor, this.props.textColor);

  render() {
    return (
      <button
        className="button"
        style={{
          backgroundColor: this.props.bkColor,
          color: this.props.textColor
        }}
        onMouseEnter={this.mouseHoverHandler} >
        {this.props.text}
      </button >
    )
  };
}

function DisplayBlock(props) {
  return (
    <div
      className="display-block"
      style={{
        backgroundColor: props.bkColor,
        color: props.textColor
      }}>
      React
    </div>
  );
}

class App extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      displayColor: "green",
      textColor: "white"
    };
  }

  stateFunc = (newBkColor, newTextColor) => {
    this.setState({
      displayColor: newBkColor,
      textColor: newTextColor
    });
  }

  render() {
    return (
      <>
        <div className='buttons-menu'>
          <Button bkColor="red" textColor="white" text="Red" onHoverAct={this.stateFunc}></Button>
          <Button bkColor="blue" textColor="white" text="Blue" onHoverAct={this.stateFunc}></Button>
          <Button bkColor="yellow" textColor="black" text="Yellow" onHoverAct={this.stateFunc}></Button>
        </div>
        <DisplayBlock bkColor={this.state.displayColor} textColor={this.state.textColor}></DisplayBlock>
      </>
    );
  }
}

export default App;
