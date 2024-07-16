import ShakespeareInfo from './ShakespeareBio';
import ShakespearePhoto from './ShakespearePhoto';
import ShakespearePoem from './ShakespearePoem';
import poems from './poems';
import './App.css';

function App() {
  return (
    <div className="app-container">
      <div className="info-photo-container">
        <ShakespearePhoto />
        <ShakespeareInfo />
      </div>
      <ShakespearePoem
        title="Sonnet 66"
        poem={poems.sonnet66}
      />
      <ShakespearePoem
        title="Sonnet 111"
        poem={poems.sonnet111}
      />
    </div>
  );
}

export default App;
