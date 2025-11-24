import asyncio


async def worker(item, max_neg, res, accuracy_and_duration_amplifier):
    delay_ms = (item - max_neg) * accuracy_and_duration_amplifier
    await asyncio.sleep(delay_ms / 1000.0)
    res.append(item)


async def sortArrayAsync(items, accuracy_and_duration_amplifier=1):
    max_neg = min(0, *items)
    res = []

    tasks = [asyncio.create_task(
        worker(item, max_neg, res, accuracy_and_duration_amplifier)) for item in items]
    await asyncio.gather(*tasks)
    print(res)
