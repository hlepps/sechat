import { useEffect, useState } from 'react';
import './App.css';
import Messenger from './components/messenger';

interface Forecast {
    date: string;
    temperatureC: number;
    temperatureF: number;
    summary: string;
}

function App() {

    return (
        <div>
            <h1 id="tableLabel">sechat</h1>
            <Messenger sender={123} receiver={321}></Messenger>
        </div>
    );

}

export default App;