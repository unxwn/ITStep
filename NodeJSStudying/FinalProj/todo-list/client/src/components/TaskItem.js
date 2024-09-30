import React from 'react';
import { useNavigate } from 'react-router-dom';

function TaskItem({ task, deleteTask }) {
  const navigate = useNavigate();

  const handleEditRedirect = () => {
    navigate(`/edit-task/${task.id}`);
  };

  const getPriorityStyle = (priority) => {
    switch (priority) {
      case 'Low':
        return { color: 'green' };
      case 'Medium':
        return { color: 'orange' };
      case 'High':
        return { color: 'red' };
      case 'None':
      default:
        return { color: 'white' };
    }
  };

  return (
    <li className="task-item">
      <h3>{task.name}</h3>
      <p>{task.description}</p>
      <p>Priority: <span style={getPriorityStyle(task.priority)}>{task.priority}</span></p>
      <p>Category: {task.category !== 'None' ? task.category : 'None'}</p>
      <p>Due: {new Date(task.datetime).toLocaleString()}</p>
      <p>Tags: {task.tags.join(', ')}</p> {/* Отображение тегов */}
      <button onClick={handleEditRedirect}>Edit</button>
      <button onClick={() => deleteTask(task.id)}>Delete</button>
    </li>
  );
}

export default TaskItem;