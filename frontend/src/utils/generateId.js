
export default function generateId() {

    return crypto.randomUUID().slice(0, 7);
}

