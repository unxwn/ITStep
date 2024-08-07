import { Me, MaFrend } from './Users';
import UserProfile from './UserProfile';
import './App.css';

function App() {
  return (
    <div className="App">
      {/* <UserProfile user={Me} /> */}
      <UserProfile user={MaFrend} />
    </div>
  );
}

export default App;
