import React, { useState } from 'react';
import TaskItem from './TaskItem';

function TaskList({ tasks, deleteTask, editTask }) {
  const [sortField, setSortField] = useState('priority');
  const [sortOrder, setSortOrder] = useState('asc');
  const [selectedPriorities, setSelectedPriorities] = useState([]);

  const handleSortFieldChange = (e) => {
    setSortField(e.target.value);
  };

  const handleSortOrderChange = (e) => {
    setSortOrder(e.target.value);
  };

  const handlePriorityFilterChange = (e) => {
    const { value, checked } = e.target;
    setSelectedPriorities(prev =>
      checked
        ? [...prev, value]
        : prev.filter(p => p !== value)
    );
  };

  const getPriorityValue = (priority) => {
    switch (priority) {
      case 'None':
        return 0;
      case 'Low':
        return 1;
      case 'Medium':
        return 2;
      case 'High':
        return 3;
      default:
        return -1;
    }
  };

  const filteredTasks = tasks.filter(task => {
    if (selectedPriorities.length > 0 && !selectedPriorities.includes(task.priority)) return false;
    return true;
  });

  const sortedTasks = [...filteredTasks].sort((a, b) => {
    let compareValue;

    if (sortField === 'priority') {
      compareValue = getPriorityValue(a.priority) - getPriorityValue(b.priority);
    } else if (sortField === 'datetime') {
      compareValue = new Date(a.datetime) - new Date(b.datetime);
    } else {
      compareValue = a[sortField].localeCompare(b[sortField]);
    }

    return sortOrder === 'asc' ? compareValue : -compareValue;
  });

  return (
    <div>
      <div className="sorting-controls">
        <div className='sort-by-text'>
          <label>Sort by: </label>
          <select value={sortField} onChange={handleSortFieldChange}>
            <option value="priority">Priority</option>
            <option value="datetime">Due date</option>
            <option value="name">Task name</option>
            <option value="category">Category</option>
          </select>
          <select value={sortOrder} onChange={handleSortOrderChange}>
            <option value="asc">Ascending</option>
            <option value="desc">Descending</option>
          </select>
        </div>
        <div>
          <label>Filter: </label>
          <label className="priority-label low">
            <input type="checkbox" value="Low" onChange={handlePriorityFilterChange} />Low
          </label>
          <label className="priority-label medium">
            <input type="checkbox" value="Medium" onChange={handlePriorityFilterChange} />Medium
          </label>
          <label className="priority-label high">
            <input type="checkbox" value="High" onChange={handlePriorityFilterChange} />High
          </label>
        </div>
      </div>

      <ul className="task-list">
        {sortedTasks.map(task => (
          <TaskItem
            key={task.id}
            task={task}
            deleteTask={deleteTask}
            editTask={editTask}
          />
        ))}
      </ul>
    </div>
  );
}

export default TaskList;