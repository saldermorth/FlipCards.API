const API_BASE =
    "https://localhost:7122";


export async function saveText(text) {
    await fetch(`${API_BASE}/api/text`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ text })
    });
}

export async function sendMessage(msg) {
    await fetch(`${API_BASE}/api/queue/send`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ message: msg })
    });
}

export async function receiveMessage() {
    const res = await fetch(`${API_BASE}/api/queue/receive`);
    if (res.status === 204) return null;
    return res.text();
}

export async function getFlipCards() {
    const res = await fetch(`${API_BASE}/api/flipcards`);

    if (!res.ok) {
        throw new Error("Failed to load flipcards");
    }

    return res.json();
}
