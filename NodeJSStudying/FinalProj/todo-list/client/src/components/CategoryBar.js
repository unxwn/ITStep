import React, { useState } from 'react';

function CategoryBar({ categories, selectedCategory, setSelectedCategory, addCategory, taskCountByCategory, deleteCategory }) {
  const [newCategory, setNewCategory] = useState('');

  const handleContextMenu = (e, category) => {
    e.preventDefault();
      const shouldDelete = window.confirm(`Are you sure you want to delete the category "${category}"?`);
      if (shouldDelete) {
        deleteCategory(category);
      }
  };

  return (
    <div className="category-bar">
      <button
        key="All tasks"
        className={selectedCategory === 'All tasks' ? 'active all-tasks-category' : 'all-tasks-category'}
        onClick={() => setSelectedCategory('All tasks')}
      >
        All tasks ({taskCountByCategory['All tasks']})
      </button>
      {categories.filter(category => category !== 'All tasks').map(category => (
        <button
          key={category}
          className={selectedCategory === category ? 'active' : ''}
          onClick={() => setSelectedCategory(category)}
          onContextMenu={(e) => handleContextMenu(e, category)}
        >
          {category} ({taskCountByCategory[category]})
        </button>
      ))}
      <div className="new-category">
        <input
          type="text"
          value={newCategory}
          onChange={(e) => setNewCategory(e.target.value)}
          placeholder="New category"
        />
        <button onClick={() => { addCategory(newCategory); setNewCategory(''); }}>
          Add
        </button>
      </div>
    </div>
  );
}

export default CategoryBar;