//todo express.js
import React, { useState, useEffect } from 'react';
import { BrowserRouter as Router, Route, Routes, Link, useLocation } from 'react-router-dom';
import CategoryBar from './components/CategoryBar';
import TaskList from './components/TaskList';
import TaskForm from './components/TaskForm';
import SearchBar from './components/SearchBar';
import { mockTasks } from './mockTasks';
import './App.css';

function App() {
  const [tasks, setTasks] = useState(mockTasks);
  const [categories, setCategories] = useState(['General', 'Home', 'Work']);
  const [selectedCategory, setSelectedCategory] = useState('All tasks');
  const [searchParams, setSearchParams] = useState({});
  const [taskCountByCategory, setTaskCountByCategory] = useState({});

  useEffect(() => {
    const counts = {};
    categories.forEach(category => {
      counts[category] = tasks.filter(task => task.category === category).length;
    });
    counts['All tasks'] = tasks.length;
    setTaskCountByCategory(counts);

  }, [tasks, categories]);

  const addTask = (task) => {
    setTasks([...tasks, { ...task, id: Date.now() }]);
  };

  const deleteTask = (id) => {
    setTasks(tasks.filter(task => task.id !== id));
  };

  const editTask = (id, updatedTask) => {
    setTasks(tasks.map(task => task.id === id ? { ...task, ...updatedTask } : task));
  };

  const addCategory = (category) => {
    if (category && !categories.includes(category)) {
      setCategories([...categories, category]);
    }
  };

  const deleteCategory = (category) => {
    setCategories(categories.filter(cat => cat !== category));
    setTasks(tasks.map(task => task.category === category ? { ...task, category: 'None' } : task));
  };

  const filteredTasks = tasks.filter(task => {
    if (selectedCategory !== 'All tasks' && task.category !== selectedCategory) return false;
    if (searchParams.name && !task.name.toLowerCase().includes(searchParams.name.toLowerCase())) return false;
    if (searchParams.description && !task.description.toLowerCase().includes(searchParams.description.toLowerCase())) return false;
    if (searchParams.priority && !searchParams.priority.includes(task.priority)) return false;
    if (searchParams.tags && !task.tags.some(tag => tag.toLowerCase().includes(searchParams.tags.toLowerCase()))) return false;
    return true;
  });

  function AppContent() {
    const location = useLocation();
    const isAddTaskPage = location.pathname === '/add-task';
    const isEditTaskPage = location.pathname.startsWith('/edit-task');

    return (
      <div className="App">
        {!isAddTaskPage && !isEditTaskPage && (
          <>
            <CategoryBar
              categories={categories}
              selectedCategory={selectedCategory}
              setSelectedCategory={setSelectedCategory}
              addCategory={addCategory}
              deleteCategory={deleteCategory}
              taskCountByCategory={taskCountByCategory}
            />
            <SearchBar setSearchParams={setSearchParams} />
            <Link to="/add-task" className="add-task-button">Add task</Link>
          </>
        )}
        <Routes>
          <Route path="/" element={
            <TaskList
              tasks={filteredTasks}
              deleteTask={deleteTask}
              editTask={editTask}
            />
          } />
          <Route path="/add-task" element={
            <TaskForm addTask={addTask} categories={categories} />
          } />
          <Route path="/edit-task/:id" element={
            <TaskForm addTask={addTask} editTask={editTask} categories={categories} tasks={tasks} />
          } />
        </Routes>
      </div>
    );
  }

  return (
    <Router>
      <AppContent />
    </Router>
  );
}

export default App;