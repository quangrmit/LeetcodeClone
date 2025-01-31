function validateUsername (username) {
    return username.trim() !== ""
}

function validateRoomId (roomId) {
    return roomId.trim() !== ""
}

export {validateRoomId, validateUsername}