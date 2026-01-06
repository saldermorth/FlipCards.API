import { useEffect, useState } from "react";
import reactLogo from "./assets/react.svg";
import viteLogo from "/vite.svg";
import { saveText, sendMessage, receiveMessage, getFlipCards } from "./api/api";
import "./App.css";

function App() {
    const [cards, setCards] = useState([]);
    const [loading, setLoading] = useState(true);
    const [text, setText] = useState("");
    const [received, setReceived] = useState("");
    const [error, setError] = useState("");

    useEffect(() => {
        let cancelled = false;

        async function load() {
            try {
                const data = await getFlipCards();
                if (!cancelled) setCards(data);
            } catch {
                setError("Could not load cards. Reload page");
            } finally {
                setLoading(false);
            }
        }

        load();
        return () => (cancelled = true);
    }, []);

    async function handleReceive() {
        const msg = await receiveMessage();
        setReceived(msg ?? "No message");
    }

    return (
        <>
            <div>
                <img src={viteLogo} className="logo" alt="Vite logo" />
                <img src={reactLogo} className="logo react" alt="React logo" />
            </div>


            <hr />

            <h2>Blob + Service Bus</h2>

            <textarea
                value={text}
                onChange={e => setText(e.target.value)}
                rows={4}
            />

            <div>
                <button onClick={() => saveText(text)}>
                    Save text as .txt
                </button>

                <button onClick={() => sendMessage(text)}>
                    Send to Service Bus
                </button>

                <button onClick={handleReceive}>
                    Receive message
                </button>
            </div>

            <p><strong>Received:</strong> {received}</p>




            <h1>FlipCards</h1>

            {loading && <p>Loading cards...</p>}
            {error && <p>{error}</p>}

            {!loading && !error && (
                <div className="cards">
                    {cards.map(card => (
                        <div className="card" key={card.id}>
                            <div className="card-front">{card.front}</div>
                            <div className="card-back">{card.back}</div>
                        </div>
                    ))}
                </div>
            )}
        </>
    );
}

export default App;
