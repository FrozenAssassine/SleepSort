let test = [
    5, 9, 1, 20, 3, -1, -9, 12, 44, 7, 0, 18, -4, 23, 81, -12, 6, 55, 90, -33, 17,
    29, 4, -8, 39, 72, 11, -2, 8, 100, 63, 14, -17, 27, 32, -22, 19, 2, 47, 76,
    -5, 31, 54, -6, 13, 99, 25, -15, 22, 16, -3, 40, 77, 1, -10, 33, 21, 48, -7,
    26, 66, 58, 42, -20, 34, 3, 7, 15, -11, 36, 62, 41, 28, -19, 59, 50, 24, 10,
    -13, 64, 73, 52, 30, -14, 46, 71, 57, 35, -16, 60, 45, 53, 38, -18, 67, 56,
    43,
];

SleepSort(test).then((r) => {
    console.log(r);
});

function SleepSort(items, accuracyAndDurationAmplifier = 1) {
    return new Promise((resolve) => {
        let maxNeg = 0;

        for (let item of items) {
            if (item < maxNeg) maxNeg = item;
        }

        let res = [];

        for (let item of items) {
            const delay = item < 0 ? -(maxNeg - item) : item + -maxNeg;

            setTimeout(() => {
                res.push(item);
                if (res.length === items.length) {
                    resolve(res);
                }
            }, delay * accuracyAndDurationAmplifier);
        }
    });
}
