import React, { useEffect, useState } from 'react';

const App = () => {
    const [users, setUsers] = useState([]);
    const [trainings, setTrainings] = useState([]);
    const [selected, setSelected] = useState('');
    const [loading, setLoading] = useState(true);
    const populateUsersData = async () => {
        const response = await fetch('Users');
        const data = await response.json();
        setUsers(data);
        setLoading(false);
    };

    const populateTrainingsData = async (userId) => {
        const response = await fetch(`AllTrainingsByUser?userId=${userId}`);
        const data = await response.json();
        setTrainings(data);
    };
    const handleChange = (e) => {
        setSelected(e.target.value);
        setLoading(true);
     }
    useEffect(() => {
        if (loading) { 
            populateUsersData();
            selected!== '' && populateTrainingsData(selected);
        }
    }, [loading]);
    return (
        <div>
            <div className="headerContainer">
                {loading === true
                    ? <p><em>Loading... Please refresh once the API backend has started.</em></p>
                    : <select onChange={handleChange}>
                        <option value="">Select user</option>
                        {users.map(user =>
                            <option value={user.id}>{user.name}</option>
                        )}
                    </select>
                }
            </div>
            {trainings && trainings.length > 0
                ? <table>
                    <thead>
                        <th>distance</th>
                        <th>duration</th>
                        <th>date</th>
                        <th>start hour</th>
                        <th>location</th>
                        <th>feel</th>
                    </thead>
                    <tbody>
                        {trainings.map(training =>
                            <tr key={training.id}>
                                <td>{training.distance}</td>
                                <td>{training.duration}</td>
                                <td>{training.date}</td>
                                <td>{training.starthour}</td>
                                <td>{training.location}</td>
                                <td>{training.feel}</td>
                            </tr>
                        )}
                    </tbody>
                </table>
                : <p>Data not found</p>}
        </div>
    )
}

export default App;
