import './UserProfile.css';

function UserProfile({ user }) {
  return (
    <div className="App">
      <div className="my-photo">
        <img
          src={user.photo}
          alt="User face"
          className="profile-photo"
        />
      </div>
      <div className="info">
        <h1>
          {user.lastName}
          <br />
          {user.firstName}
          <br />
          {user.patronymic}
        </h1>
        <p>Phone number: {user.phoneNumber}</p>
        <p>Email: {user.email}</p>
        <div className="skills">
          <div className="soft-skills">
            <h2>Soft skills</h2>
            <ul>
              {user.softSkills.map(skill => <li>{skill}</li>)}
            </ul>
          </div>
          <div className="hard-skills">
            <h2>Hard skills</h2>
            <ul>
              {user.hardSkills.map(skill => <li>{skill}</li>)}
            </ul>
          </div>
        </div>
      </div>
    </div>
  );
}

export default UserProfile;