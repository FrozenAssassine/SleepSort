import asyncio

ACCURACYANDDURATIONAMPLIFIER = 1


async def worker(item, maxNeg, res):
    delay_ms = (item - maxNeg) * ACCURACYANDDURATIONAMPLIFIER
    await asyncio.sleep(delay_ms / 1000.0)
    res.append(item)


async def sortArrayAsync(items):
    maxNeg = min(0, *items)
    res = []

    tasks = [asyncio.create_task(worker(item, maxNeg, res)) for item in items]
    await asyncio.gather(*tasks)
    print(res)
