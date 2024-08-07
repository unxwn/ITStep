import { Component } from 'react';
import './UserProfile.css';

class UserProfile extends Component {
  constructor(props) {
    super(props);
    this.initialState = {
      firstName: props.user.firstName,
      lastName: props.user.lastName,
      patronymic: props.user.patronymic,
      phoneNumber: props.user.phoneNumber,
      email: props.user.email,
      city: props.user.city,
      softSkills: [...props.user.softSkills],
      hardSkills: [...props.user.hardSkills],
    };
    this.state = this.initialState;
    this.handleChange = this.handleChange.bind(this);
    this.handleSkillChange = this.handleSkillChange.bind(this);
    this.addSkill = this.addSkill.bind(this);
    this.removeSkill = this.removeSkill.bind(this);
    this.resetForm = this.resetForm.bind(this);
  }

  handleChange(event) {
    const { name, value } = event.target;
    this.setState({ [name]: value });
  }

  handleSkillChange(event, index, skillType) {
    const newSkills = [...this.state[skillType]];
    newSkills[index] = event.target.value;
    this.setState({ [skillType]: newSkills });
  }

  addSkill(skillType) {
    const newSkills = [...this.state[skillType], ''];
    this.setState({ [skillType]: newSkills });
  }

  removeSkill(index, skillType) {
    const newSkills = this.state[skillType].filter((_, i) => i !== index);
    this.setState({ [skillType]: newSkills });
  }

  resetForm() {
    this.setState(this.initialState);
  }

  render() {
    return (
      <div className="App">
        <div className="personal-info">
          <img
            src={this.props.user.photo}
            alt="User face"
            className="profile-photo"
          />

          <div className='info'>
            <h1>
              <div className="input-label">
                <label>Last Name:</label>
                <input
                  type="text"
                  name="lastName"
                  value={this.state.lastName}
                  onChange={this.handleChange}
                />
              </div>
              <div className="input-label">
                <label>First Name:</label>
                <input
                  type="text"
                  name="firstName"
                  value={this.state.firstName}
                  onChange={this.handleChange}
                />
              </div>
              <div className="input-label">
                <label>Patronymic:</label>
                <input
                  type="text"
                  name="patronymic"
                  value={this.state.patronymic}
                  onChange={this.handleChange}
                />
              </div>
            </h1>
            <div className="input-label">
              <label>Phone Number:</label>
              <input
                type="text"
                name="phoneNumber"
                value={this.state.phoneNumber}
                onChange={this.handleChange}
              />
            </div>
            <div className="input-label">
              <label>Email:</label>
              <input
                type="text"
                name="email"
                value={this.state.email}
                onChange={this.handleChange}
              />
            </div>
            <div className="input-label">
              <label>City:</label>
              <input
                type="text"
                name="city"
                value={this.state.city}
                onChange={this.handleChange}
              />
            </div>
          </div>
        </div>

        <div className="info">
          <div className="skills">
            <div className="soft-skills">
              <h2>Soft skills</h2>
              <div className="skill-list">
                {this.state.softSkills.map((skill, index) => (
                  <div className="skill-item">
                    <label>Skill {index + 1}:</label>
                    <input
                      type="text"
                      value={skill}
                      onChange={(e) => this.handleSkillChange(e, index, 'softSkills')}
                    />
                    <button onClick={() => this.removeSkill(index, 'softSkills')}>Remove</button>
                  </div>
                ))}
              </div>
              <button onClick={() => this.addSkill('softSkills')}>Add Soft skill</button>
            </div>
            <div className="hard-skills">
              <h2>Hard skills</h2>
              <div className="skill-list">
                {this.state.hardSkills.map((skill, index) => (
                  <div className="skill-item" key={index}>
                    <label>Skill {index + 1}:</label>
                    <input
                      type="text"
                      value={skill}
                      onChange={(e) => this.handleSkillChange(e, index, 'hardSkills')}
                    />
                    <button onClick={() => this.removeSkill(index, 'hardSkills')}>Remove</button>
                  </div>
                ))}
              </div>
              <button onClick={() => this.addSkill('hardSkills')}>Add Hard Skill</button>
            </div>
          </div>

          <button onClick={this.resetForm}>Reset</button>

        </div>
      </div>
    );
  }
}

export default UserProfile;
