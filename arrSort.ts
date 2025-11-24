function SleepSortAsync(items: number[], accuracyAndDurationAmplifier = 1) {
  return new Promise((resolve: any) => {
    let maxNeg = 0;

    for (let item of items) {
      if (item < maxNeg) maxNeg = item;
    }

    let res: number[] = [];

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
