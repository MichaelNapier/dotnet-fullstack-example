import { useState, useEffect } from 'react';
import PlayerList from './PlayerList';

const term = "Player";
const API_URL = '/player';
const POST_URL = '/player';
const headers = {
  'Content-Type': 'application/json',
};

function Player() {
  const [data, setData] = useState([]);
  const [error, setError] = useState(null);

  useEffect(() => {
    fetchPlayerData();
  }, []);

  const fetchPlayerData = () => {
    fetch(API_URL)
      .then(response => response.json())
      .then(data => setData(data))
      .catch(error => setError(error));
  };

  const handleCreate = (item) => {

    console.log(`add item: ${JSON.stringify(item)}`)

    fetch(POST_URL, {
      method: 'POST',
      headers,
      body: JSON.stringify({name: item.name, description: item.description}),
    })
      .then(response => response.json())
      .then(returnedItem => setData([...data, returnedItem]))
      .catch(error => setError(error));
  };

  const handleUpdate = (updatedItem) => {

    console.log(`update item: ${JSON.stringify(updatedItem)}`)

    fetch(`${POST_URL}/${updatedItem.id}`, {
      method: 'PUT',
      headers,
      body: JSON.stringify(updatedItem),
    })
      .then(() => setData(data.map(item => item.id === updatedItem.id ? updatedItem : item)))
      .catch(error => setError(error));
  };

  const handleDelete = (id) => {
    fetch(`${POST_URL}/${id}`, {
      method: 'DELETE',
      headers,
    })
      .then(() => setData(data.filter(item => item.id !== id)))
      .catch(error => console.error('Error deleting item:', error));
  };


  return (
    <div>
      <PlayerList
        name={term}
        data={data}
        error={error}
        onCreate={handleCreate}
        onUpdate={handleUpdate}
        onDelete={handleDelete}
      />
    </div>
  );
}

export default Player;