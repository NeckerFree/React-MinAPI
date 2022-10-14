import React, { useEffect, useState } from 'react';

const App = () => {
    const pageSize = 10;
    const [users, setUsers] = useState([]);
    const [pages, setPages] = useState(0);
    const [currentPage, setCurrentPage] = useState(0);
    const [trainings, setTrainings] = useState([]);
    const [initialIndex, setInitialIndex] = useState(0);
    const [finalIndex, setFinalIndex] = useState(0);
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
        setPages(Math.round(data.length / pageSize));
        setInitialIndex(currentPage * pageSize);
        setFinalIndex(((currentPage + 1) * pageSize) - 1);
        if (currentPage === 0) { setCurrentPage(currentPage + 1); }
        setTrainings(data.slice(initialIndex, finalIndex));
    };
    const handleChange = (e) => {
        setSelected(e.target.value);
        setLoading(true);
    }
    const clickPrevious = () => {
        setCurrentPage(currentPage - 1);
        setLoading(true);
    }
    const clickNext = () => {
        setCurrentPage(currentPage + 1);
        setLoading(true);
    }
    useEffect(() => {
        if (loading) {
            //if (users.length === 0) { 
                populateUsersData();
            //}
            populateTrainingsData(selected);
        }
    }, [loading]);
    return (
        <div className="container">
            <div className="header-container">
                {loading === true && trainings.length === 0
                    ? <p><em>Loading... Please refresh once the API backend has started.</em></p>
                    : <select onChange={handleChange}>
                        <option value="">Select user</option>
                        {users.map(user =>
                            <option value={user.id}>{user.name}</option>
                        )}
                    </select>
                }
            </div>
            <div className="indexes">
                <label className="pager">Initial: {initialIndex} </label>
                <label className="pager">Final: {finalIndex}</label>
            </div>
            <div className="body-container">
                {trainings && trainings.length > 0 && selected !== ''
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
            <div className="footer-container">
                <button disabled={currentPage <= 1 ? true : false} onClick={clickPrevious}>Previous page</button>
                <label className="pager">Current: {currentPage} of {pages}</label>
                <button disabled={currentPage === pages ? true : false} onClick={clickNext}>Next page</button>
            </div>
        </div>
    )
}

export default App;
