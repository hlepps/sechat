import React, { useState } from 'react';
import '../models/message';


interface Props {
    sender: number;
    receiver: number;
};

const Messenger: React.FC<Props> = ({ sender, receiver }) => {

    const [messages, setMessages] = useState<string[]>([]);
    const [newMessage, setNewMessage] = useState<string>("");


    const sendMessage = (e:React.FormEvent) => {
        e.preventDefault();

        setMessages([...messages, newMessage]);
        setNewMessage("");

    };

    return (

        <form onSubmit={(e) => sendMessage(e)} >
            <p>messages:</p>
            <ul>
                {messages.map(message => (
                    <li key={1}>{message}</li>
                ))}
            </ul>
            <input id="textInput" className="textInput" value={newMessage} onChange={(e) => setNewMessage(e.target.value)}></input>
            <button type="submit">send</button>
        </form>
    );
};

export default Messenger;