const express = require('express');
const cors = require('cors');
const fs = require('fs');
const path = require('path');
const app = express();
const port = process.env.PORT || 5000;

app.use(cors());
app.use(express.json());

const dataFilePath = path.join(__dirname, 'data.json');

const readData = () => {
  const data = fs.readFileSync(dataFilePath);
  return JSON.parse(data);
};

const writeData = (data) => {
  fs.writeFileSync(dataFilePath, JSON.stringify(data, null, 2));
};

app.get('/api/tasks', (req, res) => {
  const data = readData();
  res.json(data.tasks);
});

app.post('/api/tasks', (req, res) => {
  const data = readData();
  const newTask = { ...req.body, id: Date.now() };
  data.tasks.push(newTask);
  writeData(data);
  res.json(newTask);
});

app.put('/api/tasks/:id', (req, res) => {
  const data = readData();
  const taskId = parseInt(req.params.id);
  const taskIndex = data.tasks.findIndex(task => task.id === taskId);
  if (taskIndex === -1) {
    return res.status(404).json({ message: 'Task not found' });
  }
  data.tasks[taskIndex] = { ...data.tasks[taskIndex], ...req.body };
  writeData(data);
  res.json(data.tasks[taskIndex]);
});

app.delete('/api/tasks/:id', (req, res) => {
  const data = readData();
  const taskId = parseInt(req.params.id);
  data.tasks = data.tasks.filter(task => task.id !== taskId);
  writeData(data);
  res.json({ message: 'Task deleted' });
});

app.get('/api/categories', (req, res) => {
  const data = readData();
  res.json(data.categories);
});

app.post('/api/categories', (req, res) => {
  const data = readData();
  const newCategory = req.body.category;
  if (!data.categories.includes(newCategory)) {
    data.categories.push(newCategory);
    writeData(data);
  }
  res.json(data.categories);
});

app.delete('/api/categories/:category', (req, res) => {
  const data = readData();
  const category = req.params.category;
  data.categories = data.categories.filter(cat => cat !== category);
  data.tasks = data.tasks.map(task => task.category === category ? { ...task, category: 'None' } : task);
  writeData(data);
  res.json({ message: 'Category deleted' });
});

app.listen(port, () => {
  console.log(`Server is running on port ${port}`);
});