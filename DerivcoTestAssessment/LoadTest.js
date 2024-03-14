import http from 'k6/http';
import { check, sleep } from 'k6';

export let options = {
    stages: [
        { duration: '1m', target: 50 }, // Ramp-up to 50 virtual users over 1 minute
        { duration: '3m', target: 50 }, // Stay at 50 virtual users for 3 minutes
        { duration: '1m', target: 0 }, // Ramp-down to 0 virtual users over 1 minute
    ],
    thresholds: {
        http_req_duration: ['p(95)<500'], // 95% of requests should be faster than 500ms
    },
};


const API_URL = 'https://www.thecocktaildb.com/api/json/v1/1/search.php?i=vodka';

export default function () {
    let response = http.get(API_URL);
    check(response, {
        'status is 200': (r) => r.status === 200,
    });
    sleep(1);
}
