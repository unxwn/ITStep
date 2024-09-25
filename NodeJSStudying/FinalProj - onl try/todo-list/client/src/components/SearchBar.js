import React, { useState } from 'react';

function SearchBar({ setSearchParams }) {
  const [search, setSearch] = useState({
    name: '',
    description: '',
    tags: '', // Добавляем поле для поиска по тегам
    searchType: 'name',
  });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setSearch(prevSearch => ({ ...prevSearch, [name]: value }));
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    setSearchParams({
      ...search,
    });
  };

  const handleReset = () => {
    setSearch({
      name: '',
      description: '',
      tags: '',
      searchType: 'name',
    });
    setSearchParams({});
  };

  return (
    <form onSubmit={handleSubmit} className="search-bar">
      <select name="searchType" value={search.searchType} onChange={handleChange}>
        <option value="name">Search by name</option>
        <option value="description">Search by description</option>
        <option value="tags">Search by tags</option> {/* Добавляем опцию для поиска по тегам */}
      </select>
      <input
        type="text"
        name={search.searchType}
        value={search[search.searchType]}
        onChange={handleChange}
        placeholder={`Search by ${search.searchType}`}
      />
      <button type="submit">Search</button>
      <button type="button" onClick={handleReset}>Reset</button>
    </form>
  );
}

export default SearchBar;