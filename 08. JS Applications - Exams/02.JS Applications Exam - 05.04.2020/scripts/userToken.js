export default function getToken() {

    const token = localStorage.getItem('userToken');
    return token;
}