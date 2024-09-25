import React, { useState, useEffect } from 'react';
import { useNavigate, Link, useParams } from 'react-router-dom';

function TaskForm({ addTask, editTask, categories, tasks }) {
  const [task, setTask] = useState({
    name: '',
    datetime: '',
    description: '',
    priority: 'Medium',
    category: 'None',
    tags: [] // Добавляем поле для тегов
  });
  const { id } = useParams();
  const navigate = useNavigate();
  const isEditing = !!id;

  useEffect(() => {
    if (isEditing) {
      const existingTask = tasks.find(task => task.id === Number(id));
      if (existingTask) {
        setTask(existingTask)
      }
    }
  }, [id, tasks, isEditing]);

  const handleSubmit = (e) => {
    e.preventDefault();
    if (isEditing) {
      editTask(task.id, task);
    } else {
      addTask(task);
    }
    navigate('/');
  };

  const handleChange = (e) => {
    const { name, value } = e.target;
    setTask(prevTask => ({ ...prevTask, [name]: value }));
  };

  const handleTagsChange = (e) => {
    const tags = e.target.value.split(',').map(tag => tag.trim());
    setTask(prevTask => ({ ...prevTask, tags }));
  };

  const addTime = (amount, unit) => {
    let date = new Date();

    if (unit === 'hour') date.setHours(date.getHours() + amount);
    if (unit === 'day') date.setDate(date.getDate() + amount);
    if (unit === 'week') date.setDate(date.getDate() + (7 * amount));

    const timezoneOffset = date.getTimezoneOffset() * 60000;
    const localDate = new Date(date.getTime() - timezoneOffset);

    setTask(prevTask => ({
      ...prevTask,
      datetime: localDate.toISOString().slice(0, 16)
    }));
  };

  return (
    <>
      <Link to="/" className="task-list-button">Task list</Link>

      <form onSubmit={handleSubmit} className="task-form">
        <h2>{isEditing ? `Editing task: ${task.name}` : 'Add new task'}</h2>
        <div className="form-group">
          <label htmlFor="name">Task name:</label>
          <input
            id="name"
            type="text"
            name="name"
            value={task.name}
            onChange={handleChange}
            required
          />
        </div>
        <div className="form-group">
          <label htmlFor="description">Description:</label>
          <textarea
            id="description"
            name="description"
            value={task.description}
            onChange={handleChange}
          />
        </div>
        <div className="form-group">
          <label htmlFor="priority">Priority:</label>
          <select id="priority" name="priority" value={task.priority} onChange={handleChange}>
            <option value="Low">Low</option>
            <option value="Medium">Medium</option>
            <option value="High">High</option>
          </select>
        </div>
        <div className="form-group">
          <label htmlFor="category">Category:</label>
          <select id="category" name="category" value={task.category} onChange={handleChange}>
            <option value="">None</option>
            {categories.filter(category => category !== 'All tasks').map(category => (
              <option key={category} value={category}>{category}</option>
            ))}
          </select>
        </div>
        <div className="form-group">
          <label>Due date:</label>
          <input
            type="datetime-local"
            name="datetime"
            value={task.datetime}
            onChange={handleChange}
          />
          <div className="datetime-buttons">
            <button type="button" onClick={() => addTime(1, 'hour')}>+1 hour</button>
            <button type="button" onClick={() => addTime(1, 'day')}>+1 day</button>
            <button type="button" onClick={() => addTime(1, 'week')}>+1 week</button>
          </div>
        </div>
        <div className="form-group">
          <label htmlFor="tags">Tags (comma separated):</label>
          <input
            id="tags"
            type="text"
            name="tags"
            value={task.tags.join(', ')}
            onChange={handleTagsChange}
          />
        </div>
        <button type="submit" className="submit-button">
          {isEditing ? 'Save changes' : 'Add task'}
        </button>
      </form>
    </>
  );
}

export default TaskForm;