#include <iostream>
#include <mutex>
#include <thread>
#include <condition_variable>
#include <future>

#define WORKERNUM 10
class worktest
{
public:
	worktest()
	{
		m_eventHappen  = false;
		m_workingState = false;
	};

	void start()
	{
		m_workingState = true;


	};

	void finish()
	{
		m_workingState = false;
	}

	void clock()
	{
		
		std::unique_lock<std::mutex> lck(m_notifylock);
		m_eventHappen = true;
		m_notifier.notifyall();

		
	}

	static void workdetail(worktest* handler, int coreid)
	{
		while(handler->m_workingState)
		{
			
			{
				std::unique_lock <std::mutex> lck(handler->m_notifylock);
				while(!handler->m_eventHappen)
				{
					handler->m_notifier.wait(lck);
				}
			}

			std::cout<<"thread "<<coreid<<" begin to work "<<std::endl;
			for(int i=0 i< 10000;i++)
			{
				for(int j=0;j<10000;j++)
				{

				}
			}

			handler->m_promise.set_val(coreid);

		}
	}
private:
	std::mutex              m_notifylock;
	std::condition_variable m_notifier;
	std::thread             m_workerthread[WORKERNUM];
	std::future<int>        m_future;
	std::promise<int>       m_promise;
	bool                    m_eventHappen;
	bool                    m_workingState;



}
int main(int argc, char const *argv[])
{
	/* code */
	return 0;
}