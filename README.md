## Async Number Sorter
It sorts the array asynchronously by using timed delays proportional to each item's value.

I think the code speaks for itself...

```js
let items = [5, 9, 1, 20, 3, -1, -9, 12, 44, 7, 0, 18];

let maxNeg = 0;
let max = 0;
for (let item of items) {
    if (item > max) {
        max = item;
    }
    if (item < 0) {
        if (item < maxNeg) {
            maxNeg = item;
        }
    }
}

let res = [];
for (let item of items) {
    if (item < 0) {
        setTimeout(() => res.push(item), -(maxNeg - item));
    }
    else {
        setTimeout(() => res.push(item), item + -maxNeg);
    }
}


setTimeout(() => console.log(res), max + -maxNeg + 1);
```
The `accuracyAndDurationAmplifier` just scales the delays so tiny numbers like 0.00005 don’t get lost due to timer resolution—completely normal in programming.
